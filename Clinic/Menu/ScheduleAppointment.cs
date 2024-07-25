using Clinic.Utils;

namespace Clinic.Menu;

internal static class ScheduleAppointment
{
    private static Dictionary<int, string> _typesApointment = new()
    {
        { 1, "Clínico geral" },
        { 2, "Dermatologista" },
        { 3, "Endocrinologista" },
        { 4, "Nutricionista" },
        { 5, "Ortopedista" }
    };

    internal static void Init()
    {
        int optionSpecialist = ChooseExpert();
        string medicalSpecialist = _typesApointment[optionSpecialist];
        string choseDate = ChooseDate(medicalSpecialist);

        Console.WriteLine($"Foi agendado com o {_typesApointment[optionSpecialist]} para o dia {choseDate} \n");
        Console.WriteLine("Precione qualquer tecla para continuar...");
        Console.ReadKey();
        Home.Init();
    }

    private static int ChooseExpert()
    {
        int optionSpecialist;
        do
        {
            Console.Clear();
            Console.WriteLine("Selecione a especialidade que você precisa:");
            foreach (var appointment in _typesApointment)
            {
                Console.WriteLine($"({appointment.Key}) {appointment.Value}\n");
            }

            while (!SystemFormat.TryReadNumber(out optionSpecialist))
            {
                Console.WriteLine("Opção inválida! Digite um número de acordo com as opção de especialidade médica");
            }
        } while (optionSpecialist is > 5 or < 1);

        return optionSpecialist;
    }

    private static string ChooseDate(string expert)
    {
        int optionDate;
        var dates = DateRandom.GenerateListDaysAppointment(5, 10);
        do
        {
            Console.Clear();
            Console.WriteLine($"Selecione uma data para agendar a consulta: {expert}\n");
            Console.WriteLine("Precione a tecla referente ao dia e hora disponível");

            for(int i = 0; i < dates.Length; i++)
            {
                string formatedDate = SystemFormat.FormatDateTime(dates[i]);
                Console.WriteLine($"({i + 1}) {formatedDate}");
            }

            while (!SystemFormat.TryReadNumber(out optionDate))
            {
                Console.WriteLine("Opção inválida! Digite um número de acordo com as opção de data");
            }
        } while (optionDate is > 5 or < 1);

        return SystemFormat.FormatDateTime(dates[optionDate - 1]);
    }
}