using Clinic.Utils;

namespace Clinic.Menu;

public static class Home
{
    public static void Init()
    {
        var options = new Dictionary<int, string>()
        {
            { 1, "Realizar consulta" },
            { 2, "Visualizar consulta agendada" },
            { 3, "Visualizar histórico de atendimento" },
            { 4, "Sair da aplicação" }
        };

        Console.Clear();
        Console.WriteLine(@"
        ██████   ██████   ██████ ████████  ██████  ██████  ███████ 
        ██   ██ ██    ██ ██         ██    ██    ██ ██   ██ ██      
        ██   ██ ██    ██ ██         ██    ██    ██ ██████  ███████ 
        ██   ██ ██    ██ ██         ██    ██    ██ ██   ██      ██ 
        ██████   ██████   ██████    ██     ██████  ██   ██ ███████ 
        ");
        Console.WriteLine("Selecione uma opção");
        foreach (var option in options)
        {
            Console.WriteLine($"({option.Key}) {option.Value}");
        }

        int choice;
        int[] choices = options.Keys.ToArray();
        while (!SystemCommon.IsValidOption(choices, out choice))
        {
            Console.WriteLine("Opção inválida! Por favor, insira um número válido.");
        }

        switch (choice)
        {
            case 1:
                ScheduleAppointment.Init();
                break;
            case 2 :
                ShowAppointments.Init();
                break;
            default:
                Console.WriteLine("Ainda não implementado");
                break;
        }
    }
}