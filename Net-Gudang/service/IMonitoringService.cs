namespace Net_Gudang.service;

public interface IMonitoringService
{
    List<Barang> MonitoringBarang(string namaGudang, DateTime? expiredDate);
}