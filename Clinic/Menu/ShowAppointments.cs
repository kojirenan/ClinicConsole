using Clinic.Model;
using Clinic.Utils;

namespace Clinic.Menu;

internal static class ShowAppointments
{
    public static List<Appointment> Appointments { get; set; } = new();

    private static Dictionary<int, string> _options = new()
    {
        {1, "Consultas Agendadas"},
        {2, "Consultas Realizadas"},
        {3, "Consultas Cancelas"},
        {4, "Voltar"}
    };

    internal static void Init()
    {
        var chosenOption = MenuChoices();
        switch (chosenOption)
        {
            case 1:
                ShowScheduleAppointments();
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }

    private static int MenuChoices()
    {
        int chosenMenu;
        var choices = _options.Keys.ToArray();
        Console.WriteLine("Escolha umas das opções abaixo");
        foreach (var option in _options)
        {
            Console.WriteLine($"({_options.Keys}) {_options.Values}");
        }

        while (!SystemCommon.IsValidOption(choices, out chosenMenu))
        {
            Console.WriteLine("Opção inválida! Digite um número de acordo com a opção.");
        }

        return chosenMenu;
    }

    private static void ShowScheduleAppointments()
    {
        Console.WriteLine($"Você tem {Appointments.Count} consulta(s) agendada(s)\n");
        foreach (var appointment in Appointments)
        {
            Console.WriteLine($"Para o dia {appointment.Date.Day}");
        }
    }
}