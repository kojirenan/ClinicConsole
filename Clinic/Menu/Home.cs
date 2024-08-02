using Clinic.DAL;
using Clinic.Utils;

namespace Clinic.Menu;

public static class Home
{
    public static void Init()
    {
        var context = new ClinicContext();
        var appointmentDal = new AppointmentDAL(context);
        var options = new Dictionary<int, string>()
        {
            { 1, "Realizar consulta" },
            { 2, "Visualizar consultas" },
            { 3, "Editar consulta agendada" },
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
                ScheduleAppointment.Init(appointmentDal);
                break;
            case 2 :
                ShowAppointments.Init(appointmentDal);
                break;
            case 3:
                EditAppoitment.Init(appointmentDal);
                break;
            case 4:
                Console.WriteLine("Volte sempre! :)");
                break;
        }
    }
}