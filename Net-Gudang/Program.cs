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
        
        // var newGudang = new Gudang();
        // newGudang.KodeGudang = 1;
        // newGudang.NamaGudang = "Nama Gudang 1";
        
        // var newGudang2 = new Gudang();
        // newGudang2.KodeGudang = 2;
        // newGudang2.NamaGudang = "Nama Gudang 2";
        // gudangService.CreateGudang(newGudang2);

        // var newBarang1 = new Barang();
        // newBarang1.KodeBarang = 1;
        // newBarang1.NamaBarang = "Nama Barang 1";
        // newBarang1.HargaBarang = 10.2m;
        // newBarang1.JumlahBarang = 2;
        // newBarang1.ExpiredBarang = DateTime.Now;
        // newBarang1.KodeGudang = 1;
        // barangService.CreateBarang(newBarang1);

        var list = monitoringService.MonitoringBarang(null, DateTime.Now);
        foreach (var barang in list)
        {
            Console.WriteLine(barang.KodeBarang);
            Console.WriteLine(barang.NamaBarang);
            Console.WriteLine(barang.ExpiredBarang);
        }
    }
}