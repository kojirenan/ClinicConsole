using Clinic.Utils;

namespace Clinic.Menu;

public static class Home
{
    public static void Init()
    {
        Console.Clear();
        Console.WriteLine(@"
        ██████   ██████   ██████ ████████  ██████  ██████  ███████ 
        ██   ██ ██    ██ ██         ██    ██    ██ ██   ██ ██      
        ██   ██ ██    ██ ██         ██    ██    ██ ██████  ███████ 
        ██   ██ ██    ██ ██         ██    ██    ██ ██   ██      ██ 
        ██████   ██████   ██████    ██     ██████  ██   ██ ███████ 
        ");
        Console.WriteLine(@"Selecione uma opção
        (1) Realizar consulta
        (2) Visualizar consulta agendada
        (3) Visualizar histórico de atendimento
        (4) Sair da aplicação");

        int option;
        while (!SystemFormat.TryReadNumber(out option))
        {
            Console.WriteLine("Opção inválida! Por favor, insira um número.");
        }
        
        switch (option)
        {
            case 1:
                ScheduleAppointment.Init();
                break;
        }
    }
}