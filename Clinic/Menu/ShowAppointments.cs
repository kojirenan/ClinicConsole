using Clinic.Model;
using Clinic.Utils;

namespace Clinic.Menu;

internal static class ShowAppointments
{
    public static List<Appointment> Appointments { get; set; } = new();
    
    internal static void Init()
    {
        var chosenOption = MenuChoices();
        switch (chosenOption)
        {
            case 1:
                ShowScheduleAppointments();
                break;
            case 4:
                Home.Init();
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }

    private static int MenuChoices()
    {
        var options = new Dictionary<int, string>()
        {
            {1, "Consultas Agendadas"},
            {2, "Consultas Realizadas"},
            {3, "Consultas Cancelas"},
            {4, "Voltar"}
        };
        
        int chosenMenu;
        var choices = options.Keys.ToArray();
        
        Console.Clear();
        Console.WriteLine("Escolha umas das opções abaixo");
        foreach (var option in options)
        {
            Console.WriteLine($"({option.Key}) {option.Value}");
        }

        while (!SystemCommon.IsValidOption(choices, out chosenMenu))
        {
            Console.WriteLine("Opção inválida! Digite um número de acordo com a opção.");
        }

        return chosenMenu;
    }

    private static void ShowScheduleAppointments()
    {
        Console.Clear();
        Console.WriteLine($"Você tem {Appointments.Count} consulta(s) agendada(s)\n");
        foreach (var appointment in Appointments)
        {
            var formatedDate = SystemCommon.FormatDateTime(appointment.Date);
            Console.WriteLine($"Para o dia {formatedDate} com {appointment.Specialty}");
        }

        Console.WriteLine("Precione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Init();
    }
}