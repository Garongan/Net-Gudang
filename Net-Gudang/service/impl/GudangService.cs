using Microsoft.Data.SqlClient;
using Net_Gudang.constant;

namespace Net_Gudang.service.impl;

public class GudangService : IGudangService
{
    public void CreateGudang(Gudang gudang)
    {
        using SqlConnection conn = new SqlConnection(ConnectionString.ConnectionUrl);
        string query = "INSERT INTO Gudang (KodeGudang, NamaGudang) VALUES (@KodeGudang, @NamaGudang)";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@KodeGudang", gudang.KodeGudang);
        cmd.Parameters.AddWithValue("@NamaGudang", gudang.NamaGudang);
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public Gudang? GetGudang(int kodeGudang)
    {
        using SqlConnection conn = new SqlConnection(ConnectionString.ConnectionUrl);
        string query = "SELECT * FROM Gudang WHERE KodeGudang = @KodeGudang";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@KodeGudang", kodeGudang);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new Gudang
            {
                KodeGudang = (int)reader["KodeGudang"],
                NamaGudang = (string)reader["NamaGudang"]
            };
        }

        return null;
    }

    public void UpdateGudang(Gudang gudang)
    {
        using SqlConnection conn = new SqlConnection(ConnectionString.ConnectionUrl);
        string query = "UPDATE Gudang SET NamaGudang = @NamaGudang WHERE KodeGudang = @KodeGudang";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@KodeGudang", gudang.KodeGudang);
        cmd.Parameters.AddWithValue("@NamaGudang", gudang.NamaGudang);
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void DeleteGudang(int kodeGudang)
    {
        using SqlConnection conn = new SqlConnection(ConnectionString.ConnectionUrl);
        string query = "DELETE FROM Gudang WHERE KodeGudang = @KodeGudang";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@KodeGudang", kodeGudang);
        conn.Open();
        cmd.ExecuteNonQuery();
    }
}