using System;

class Program {
    static void Main() {
        CovidConfig configClass = new CovidConfig();
        
        // Menjalankan Input sesuai CONFIG1
        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {configClass.conf.satuan_suhu}: ");
        double suhu = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hariDemam = int.Parse(Console.ReadLine());

        // Validasi Kondisi 
        bool suhuValid = false;
        if (configClass.conf.satuan_suhu == "celcius") {
            suhuValid = (suhu >= 36.5 && suhu <= 37.5);
        } else if (configClass.conf.satuan_suhu == "fahrenheit") {
            suhuValid = (suhu >= 97.7 && suhu <= 99.5);
        }

        bool demamValid = hariDemam < configClass.conf.batas_hari_demam;

        if (suhuValid && demamValid) {
            Console.WriteLine(configClass.conf.pesan_diterima);
        } else {
            Console.WriteLine(configClass.conf.pesan_ditolak);
        }

        // Memanggil UbahSatuan
        configClass.UbahSatuan();
    }
}