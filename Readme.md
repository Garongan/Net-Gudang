## Inventory Management System

### 1. Antisipasi pengecekan barang kadaluarsa
Algoritma yang dipakai adalah sebagai berikut:

- Setiap barang di gudang memiliki atribut ExpiredDate.
- Melakukan pengecekan setiap hari, apakah tanggal hari ini sudah melewati expired date.
- Jika barang tersebut kadaluarsa, cetak dalam laporan dan keluarkan dari gudang.

### 2. Gudang SQL
- membuat tabel Gudang dan Barang
```sql
CREATE TABLE Gudang (
	KodeGudang INT PRIMARY KEY,
	NamaGudang VARCHAR(100) NOT NULL
);
CREATE TABLE Barang (
	KodeBarang INT PRIMARY KEY,
	NamaBarang VARCHAR(100) NOT NULL,
	HargaBarang DECIMAL(18, 2) NOT NULL,
	ExpiredBarang DATE NOT NULL,
	JumlahBarang INT,
	KodeGudang INT,
	FOREIGN KEY (KodeGudang) REFERENCES Gudang(KodeGudang)
);
CREATE INDEX idx_ExpiredBarang ON Barang (ExpiredBarang);
```
- membuat store procedure dengan dynamic query dan paging
```sql
GO
CREATE PROCEDURE GetBarangWithPaging
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

    DECLARE @SQL NVARCHAR(MAX) = '
        SELECT g.KodeGudang, g.NamaGudang, b.KodeBarang, b.NamaBarang, 
               b.HargaBarang, b.JumlahBarang, b.ExpiredBarang
        FROM Gudang g
        INNER JOIN Barang b ON g.KodeGudang = b.KodeGudang
        ORDER BY b.KodeBarang
        OFFSET ' + CAST(@Offset AS NVARCHAR(MAX)) + ' ROWS
        FETCH NEXT ' + CAST(@PageSize AS NVARCHAR(MAX)) + ' ROWS ONLY';

    EXEC sp_executesql @SQL;
END;
GO
```
- membuat trigger ketika input barang dan memunculkan barang yang kadaluarsa
```sql
GO
CREATE TRIGGER CheckBarangKadaluarsa
ON Barang
AFTER INSERT
AS
BEGIN
    SELECT *
    FROM inserted
    WHERE ExpiredBarang <= GETDATE();
END;
GO
```
### 3. CRUD di Gudang
- CRUD untuk gudang [gudang service](./Net-Gudang/service/impl/GudangService.cs)
- CRUD untuk barang dengan dropdown data gudang [barang service](./Net-Gudang/service/impl/BarangService.cs)
- Monitoring barang [monitoring service](./Net-Gudang/service/impl/MonitoringService.cs)
