namespace Net_Gudang.service;

public interface IBarangService
{
    void CreateBarang(Barang barang);
    Barang? GetBarang(int KodeBarang);
    void UpdateBarang(Barang barang);
    void DeleteBarang(int KodeBarang);
    List<Gudang> GetAllGudang();
}