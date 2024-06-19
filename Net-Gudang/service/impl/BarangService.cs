using Microsoft.Data.SqlClient;
using Net_Gudang.constant;

namespace Net_Gudang.service.impl;

public class BarangService : IBarangService
{
    public void CreateBarang(Barang barang)
    {
        using SqlConnection conn = new SqlConnection(ConnectionString.ConnectionUrl);
        string query =
            "INSERT INTO Barang (KodeBarang, NamaBarang, HargaBarang, JumlahBarang, ExpiredBarang, KodeGudang) " +
            "VALUES (@KodeBarang, @NamaBarang, @HargaBarang, @JumlahBarang, @ExpiredBarang, @KodeGudang)";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@KodeBarang", barang.KodeBarang);
        cmd.Parameters.AddWithValue("@NamaBarang", barang.NamaBarang);
        cmd.Parameters.AddWithValue("@HargaBarang", barang.HargaBarang);
        cmd.Parameters.AddWithValue("@JumlahBarang", barang.JumlahBarang);
        cmd.Parameters.AddWithValue("@ExpiredBarang", barang.ExpiredBarang);
        cmd.Parameters.AddWithValue("@KodeGudang", barang.KodeGudang);
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public Barang? GetBarang(int kodeBarang)
    {
        using SqlConnection conn = new SqlConnection(ConnectionString.ConnectionUrl);
        string query = "SELECT * FROM Barang WHERE KodeBarang = @KodeBarang";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@KodeBarang", kodeBarang);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new Barang
            {
                KodeBarang = (int)reader["KodeBarang"],
                NamaBarang = (string)reader["NamaBarang"],
                HargaBarang = (decimal)reader["HargaBarang"],
                JumlahBarang = (int)reader["JumlahBarang"],
                ExpiredBarang = (DateTime)reader["ExpiredBarang"],
                KodeGudang = (int)reader["KodeGudang"]
            };
        }

        return null;
    }

    public void UpdateBarang(Barang barang)
    {
        using SqlConnection conn = new SqlConnection(ConnectionString.ConnectionUrl);
        string query =
            "UPDATE Barang SET NamaBarang = @NamaBarang, HargaBarang = @HargaBarang, JumlahBarang = @JumlahBarang, " +
            "ExpiredBarang = @ExpiredBarang, KodeGudang = @KodeGudang WHERE KodeBarang = @KodeBarang";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@KodeBarang", barang.KodeBarang);
        cmd.Parameters.AddWithValue("@NamaBarang", barang.NamaBarang);
        cmd.Parameters.AddWithValue("@HargaBarang", barang.HargaBarang);
        cmd.Parameters.AddWithValue("@JumlahBarang", barang.JumlahBarang);
        cmd.Parameters.AddWithValue("@ExpiredBarang", barang.ExpiredBarang);
        cmd.Parameters.AddWithValue("@KodeGudang", barang.KodeGudang);
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void DeleteBarang(int kodeBarang)
    {
        using SqlConnection conn = new SqlConnection(ConnectionString.ConnectionUrl);
        string query = "DELETE FROM Barang WHERE KodeBarang = @KodeBarang";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@KodeBarang", kodeBarang);
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public List<Gudang> GetAllGudang()
    {
        using SqlConnection conn = new SqlConnection(ConnectionString.ConnectionUrl);
        string query = "SELECT KodeGudang, NamaGudang FROM Gudang";
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        List<Gudang> gudangs = new List<Gudang>();
        while (reader.Read())
        {
            gudangs.Add(new Gudang
            {
                KodeGudang = (int)reader["KodeGudang"],
                NamaGudang = (string)reader["NamaGudang"]
            });
        }

        return gudangs;
    }
}