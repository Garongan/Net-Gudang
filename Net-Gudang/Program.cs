using Net_Gudang.service.impl;

namespace Net_Gudang;

public static class Program
{
    public static void Main(string[] args)
    {
        var gudangService = new GudangService();
        var barangService = new BarangService();
        var monitoringService = new MonitoringService();
        
        // lakukan operasi yang ada di interface gudang, barang, atau monitoring sesuai kebutuhan
    }
}