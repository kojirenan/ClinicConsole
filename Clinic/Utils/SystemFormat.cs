using System.Globalization;

namespace Clinic.Utils;

public static class SystemFormat
{
    public static string FormatDateTime(DateTime dateTime)
    {
        CultureInfo culture = new CultureInfo("pt-BR");
        string formattedDate = dateTime.ToString("f", culture);
        return formattedDate;
    }
    
    public static bool TryReadNumber(out int number)
    {
        string input = Console.ReadLine();
        return int.TryParse(input, out number);
    }
}