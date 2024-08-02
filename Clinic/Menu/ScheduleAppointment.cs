using Clinic.DAL;
using Clinic.Model;
using Clinic.Utils;

namespace Clinic.Menu;

internal static class ScheduleAppointment
{
    private static Dictionary<int, string> _typesApointment = new()
    {
        { 1, "Clínico Geral" },
        { 2, "Dermatologista" },
        { 3, "Endocrinologista" },
        { 4, "Nutricionista" },
        { 5, "Ortopedista" }
    };

    internal static void Init(AppointmentDAL appointmentDal)
    {
        string medicalSpecialist;
        DateTime chosenDate;
        string formatedDate;
        do
        {
            int optionSpecialist = ChooseExpert();
            medicalSpecialist = _typesApointment[optionSpecialist];
        } while (!SystemCommon.Confirmation($"Consulta com {medicalSpecialist}"));

        do
        {
            chosenDate = ChooseDate(medicalSpecialist);
            formatedDate = SystemCommon.FormatDateTime(chosenDate);
        } while (!SystemCommon.Confirmation($"Consulta com {medicalSpecialist} para a data {formatedDate}"));

        var appointment = new Appointment(medicalSpecialist, "Renan Koji", chosenDate);
        appointmentDal.Add(appointment);
        
        Console.Clear();
        Console.WriteLine("Parábens sua consulta foi marcada");
        Console.WriteLine($"Especialista: {medicalSpecialist} para o dia {formatedDate} \n");
        Console.WriteLine("Precione qualquer tecla para continuar...");
        Console.ReadKey();
        Home.Init();
    }

    private static int ChooseExpert()
    {
        int optionSpecialist;
        int[] options = _typesApointment.Keys.ToArray();

        Console.Clear();
        Console.WriteLine("Selecione a especialidade que você precisa:");
        foreach (var appointment in _typesApointment)
        {
            Console.WriteLine($"({appointment.Key}) {appointment.Value}\n");
        }

        while (!SystemCommon.IsValidOption(options, out optionSpecialist))
        {
            Console.WriteLine("Opção inválida! Digite um número de acordo com as opção de especialidade médica");
        }

        return optionSpecialist;
    }

    private static DateTime ChooseDate(string expert)
    {
        int chosenDate;
        var randomDates = DateRandom.GenerateListDaysAppointment(5, 10);
        var validOptions = new int[randomDates.Length];
        var dateOptions = new Dictionary<int, DateTime>();

        // Converts to a dictionary to allow with a pair choose.
        // Create an array of options.
        for (int i = 0; i < randomDates.Length; i++)
        {
            validOptions[i] = i + 1;
            dateOptions.Add(i + 1, randomDates[i]);
        }

        Console.Clear();
        Console.WriteLine($"Selecione uma data para agendar a consulta: {expert}\n");
        Console.WriteLine("Precione a tecla referente ao dia e hora disponível");
        foreach (var option in dateOptions)
        {
            var formatedDate = SystemCommon.FormatDateTime(option.Value);
            Console.WriteLine($"({option.Key}) {formatedDate}");
        }

        while (!SystemCommon.IsValidOption(validOptions, out chosenDate))
        {
            Console.WriteLine("Opção inválida! Digite um número de acordo com as opção de data");
        }

        return dateOptions[chosenDate];
    }
}