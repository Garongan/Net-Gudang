using Microsoft.Data.SqlClient;
using Net_Gudang.constant;

namespace Net_Gudang.service.impl;

public class MonitoringService : IMonitoringService
{
    public List<Barang> MonitoringBarang(string? namaGudang, DateTime? expiredDate)
    {
        using SqlConnection conn = new SqlConnection(ConnectionString.ConnectionUrl);
        var query =
            "SELECT b.KodeBarang, b.NamaBarang, b.HargaBarang, b.JumlahBarang, b.ExpiredBarang, b.KodeGudang " +
            "FROM Barang b " +
            "INNER JOIN Gudang g ON b.KodeGudang = g.KodeGudang " +
            "WHERE (@NamaGudang IS NULL OR g.NamaGudang = @NamaGudang) " +
            "AND (@ExpiredDate IS NULL OR b.ExpiredBarang <= @ExpiredDate)";
        SqlCommand cmd = new SqlCommand(query, conn);
        Console.WriteLine(expiredDate);
        cmd.Parameters.AddWithValue("@NamaGudang", (object)namaGudang! ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ExpiredDate", (object)expiredDate! ?? DBNull.Value);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        List<Barang> listBarang = new List<Barang>();
        while (reader.Read())
        {
            listBarang.Add(new Barang
            {
                KodeBarang = (int)reader["KodeBarang"],
                NamaBarang = (string)reader["NamaBarang"],
                HargaBarang = (decimal)reader["HargaBarang"],
                JumlahBarang = (int)reader["JumlahBarang"],
                ExpiredBarang = (DateTime)reader["ExpiredBarang"],
                KodeGudang = (int)reader["KodeGudang"]
            });
        }

        return listBarang;
    }
}