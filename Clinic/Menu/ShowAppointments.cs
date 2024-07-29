using Clinic.DAL;
using Clinic.Model;
using Clinic.Utils;

namespace Clinic.Menu;

internal static class ShowAppointments
{
    private static Dictionary<int, string> _options = new()
    {
        { 1, "Consultas Agendadas" },
        { 2, "Histórico de Consultas" },
        { 3, "Voltar" }
    };

    // TO-DO: improve the code
    private static readonly List<Appointment> Appointments = AppointmentDAL.Appointments;

    internal static void Init()
    {
        var chosenOption = MenuChoices();
        switch (chosenOption)
        {
            case 1:
                ShowScheduleAppointments();
                break;
            case 2:
                ShowAllAppointments();
                break;
            case 3:
                Home.Init();
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

        Console.Clear();
        Console.WriteLine("Escolha umas das opções abaixo");
        foreach (var option in _options)
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
        Console.WriteLine($"Você tem as seguintes consulta(s) agendada(s):\n");
        foreach (var appointment in Appointments)
        {
            if (appointment.Date > DateTime.Now)
            {
                var formatedDate = SystemCommon.FormatDateTime(appointment.Date);
                Console.WriteLine($"Para o dia {formatedDate} com {appointment.Specialty}");
            }
        }

        Console.WriteLine("Precione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Init();
    }

    private static void ShowAllAppointments()
    {
        Console.Clear();
        Console.WriteLine("Histórico de consultas: \n\n");
        foreach (var appointment in Appointments)
        {
            var formatedDate = SystemCommon.FormatDateTime(appointment.Date);
            string status = appointment.IsCarriedOut == false && appointment.Date < DateTime.Now
                ? "Cancelada"
                : "Realizada";

            Console.WriteLine($"Consulta com : {appointment.Specialty} \n" +
                              $"Data: {formatedDate} \n" +
                              $"Status: {status} \n\n");
        }

        Console.WriteLine("Precione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Init();
    }
}