using System;
using modul8_103022330059;

public class Program
{
    public static void Main(string[] args)
    {
        UIConfig config = new UIConfig();
        config.ReadConfigFIle();

        if (config.banktransferconfig.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
        }
        else if (config.banktransferconfig.lang == "id")
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di transfer:");
        }

        if (int.TryParse(Console.ReadLine(), out int amount))
        {
            if (amount < config.banktransferconfig.transfer.treshold)
            {
                Console.WriteLine($"Transfer fee: {config.banktransferconfig.transfer.low_fee}");
            }
            else
            {
                Console.WriteLine($"Transfer fee: {config.banktransferconfig.transfer.high_fee}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        Console.WriteLine("Please select a transfer method:");
        for (int i = 0; i < config.banktransferconfig.methods.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {config.banktransferconfig.methods[i]}");
        }
        if (int.TryParse(Console.ReadLine(), out int methodIndex) && methodIndex > 0 && methodIndex <= config.banktransferconfig.methods.Length)
        {
            Console.WriteLine($"You selected: {config.banktransferconfig.methods[methodIndex - 1]}");
        }
        else
        {
            Console.WriteLine("Invalid selection. Please select a valid transfer method.");
        }
        Console.WriteLine("Do you want to confirm the transfer? (yes/no)");
        string confirmation = Console.ReadLine();
        if (confirmation.ToLower() == "yes" || confirmation.ToLower() == config.banktransferconfig.confirmation.en)
        {
            Console.WriteLine("Transfer confirmed.");
        }
        else if (confirmation.ToLower() == "no" || confirmation.ToLower() == config.banktransferconfig.confirmation.id)
        {
            Console.WriteLine("Transfer cancelled.");
        }
        else
        {
            Console.WriteLine("Invalid confirmation. Please enter 'yes' or 'no'.");
        }
    }    
}
