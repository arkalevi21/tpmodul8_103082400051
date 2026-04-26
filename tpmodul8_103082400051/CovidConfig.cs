using System;
using System.IO;
using System.Text.Json;

public class Config {
    public string satuan_suhu { get; set; } // CONFIG1
    public int batas_hari_demam { get; set; } // CONFIG2
    public string pesan_ditolak { get; set; } // CONFIG3
    public string pesan_diterima { get; set; } // CONFIG4

    public Config() { } // Constructor kosong untuk Deserialisasi
}

public class CovidConfig {
    public Config conf;
    private const string filePath = "covid_config.json";

    public CovidConfig() {
        try {
            ReadConfigFile();
        } catch {
            SetDefault();
            WriteConfigFile();
        }
    }

    private void SetDefault() {
        conf = new Config {
            satuan_suhu = "celcius",
            batas_hari_demam = 14,
            pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
            pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
        };
    }

    private void ReadConfigFile() {
        string jsonString = File.ReadAllText(filePath);
        conf = JsonSerializer.Deserialize<Config>(jsonString);
    }

    private void WriteConfigFile() {
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(conf, options);
        File.WriteAllText(filePath, jsonString);
    }

    public void UbahSatuan() {
        conf.satuan_suhu = conf.satuan_suhu == "celcius" ? "fahrenheit" : "celcius";
    }
}