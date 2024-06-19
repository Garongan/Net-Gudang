namespace Net_Gudang.service;

public interface IGudangService
{
    void CreateGudang(Gudang gudang);
    Gudang? GetGudang(int KodeGudang);
    void UpdateGudang(Gudang gudang);
    void DeleteGudang(int KodeGudang);
}