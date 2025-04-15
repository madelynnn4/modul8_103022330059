using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022330059
{
    public class BankTransferConfig
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public string[] methods { get; set; }
        public Confirmation confirmation { get; set; }

    }
    public class Transfer
    {
        public int treshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
    }

    public class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }
    }
    public class UIConfig
    {
        public BankTransferConfig banktransferconfig;
        public const String filePath = "banktransferconfig.json";
        public BankTransferConfig ReadConfigFIle()
        {
            string configJsonData = File.ReadAllText(filePath);
            banktransferconfig = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData); return banktransferconfig;
        }
        public void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(banktransferconfig);
            File.WriteAllText(filePath, json);
        }
        public void SetDefaultConfig()
        {
            banktransferconfig = new BankTransferConfig
            {
                lang = "en",
                transfer = new Transfer
                {
                    treshold = 25000000,
                    low_fee = 6500,
                    high_fee = 15000
                },
                methods = new string[] { "RTO (real-time)", "SKN", "RTGS", "BI FAST" },
                confirmation = new Confirmation
                {
                    en = "yes",
                    id = "ya"
                }
            };
            WriteConfigFile();
        }
        public UIConfig()
        {
            try
            {
                ReadConfigFIle();
            }
            catch (Exception)
            {
                SetDefaultConfig();
                WriteConfigFile();
            }
        }

    }
}
