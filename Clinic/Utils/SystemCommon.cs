using System.Globalization;

namespace Clinic.Utils;

public static class SystemCommon
{
    public static string FormatDateTime(DateTime dateTime)
    {
        CultureInfo culture = new CultureInfo("pt-BR");
        string formattedDate = dateTime.ToString("dd/MM/yy - HH:mm, dddd", culture);
        return formattedDate;
    }

    public static bool IsValidOption(int[] options, out int valid)
    {
        valid = -1;
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int number))
        {
            return false;
        }
        
        if(Array.Exists(options, option => option.Equals(number)))
        {
            valid = number;
            return true;
        }

        return false;
    }

    public static bool Confirmation(string confirmation)
    {
        int option;
        int[] agree =  { 1, 2 };
        Console.Clear();
        Console.WriteLine($"{confirmation}\n");
        Console.WriteLine("Deseja confirmar a escolha:");
        Console.Write("(1) SIM \t");
        Console.WriteLine("(2) NÃO");
        while (!IsValidOption(agree, out option))
        {
            Console.WriteLine("Opção inválida! Escolha uma opção válida.");
        }
        return option == 1;
    }
}