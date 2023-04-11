// See https://aka.ms/new-console-template for more information
using System.Diagnostics.SymbolStore;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;

public class Program
{
    private static void Main(string[] args)
    {
        AppBank appBank = new AppBank();
        string transfer = Console.ReadLine();
        int tottransfer = Convert.ToInt32(transfer);
        Console.WriteLine("Please insert the amount of money to transfer: ");
        Console.WriteLine("masukkan jumlah uang yang akan di-transfer: ");

        if(tottransfer <= 25000000)
        {
            Console.WriteLine("6500");
        }
        else
        {
            Console.WriteLine("15000");

        }


    }
}

public class AppBank
{
    public BankConfig bank;

    private const string fileLocation = "D:\\jurnal8\\jurnal_mod8_1302213052\\Modul8_1302213052\\Modul8_1302213052";

    public AppBank()
    {
        try
        {
            ReadConfigFile();
        }
        catch
        {
            writeConfigFile();
        
        }
        
    }
    private BankConfig ReadConfigFile()
    {
        string hasilbaca = File.ReadAllText(fileLocation);
        bank = JsonSerializer.Deserialize<BankConfig>(hasilbaca);
        return bank;
    }

    private void writeConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        string textTulis = JsonSerializer.Serialize(bank, options);
        File.WriteAllText(fileLocation, textTulis);
    }   
}

public class BankConfig
{
    public string lang { get; set; }
    public Transfer transfer { get; set; }  
    public List<BankConfig> methods { get; set; }
    public Confirmation confirmation { get; set; }
    public BankConfig() { }
    public BankConfig(string lang, Transfer transfer, List<BankConfig> methods, Confirmation confirmation)
    {
        this.lang = lang;
        this.transfer = transfer;   
        this.methods = methods;
        this.confirmation = confirmation;
    }
}

public class Transfer 
{ 
    public int low_fee { get; set; }    
    public int high_fee { get; set; }

    public Transfer() { }
    public Transfer(int low_fee, int high_fee)
    {
        this.low_fee = low_fee;
        this.high_fee = high_fee;
    }
}

public class Confirmation
{
    public string en { get; set; }
    public string id { get; set; }
    public Confirmation()
    {

    }
    public Confirmation(string en, string id)
    {
        this.en = en;       
        this.id = id;
    }
}


