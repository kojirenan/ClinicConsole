using Clinic.DAL;
using Clinic.Model;
using Clinic.Utils;

namespace Clinic.Menu;

internal static class EditAppoitment
{
    internal static void Init(AppointmentDAL appointmentDal)
    {
        while (true)
        {
            var appointments = appointmentDal.List()
                .Where(appointment => appointment.IsCarriedOut == false && appointment.Date > DateTime.Today)
                .Select((appointment, index) => new { Key = index + 1, Value = appointment })
                .ToDictionary(x => x.Key, x => x.Value);
            var chosenOption = MenuChoices(appointments);

            if (chosenOption == 0) break;
            ChangeAppointment(appointmentDal, appointments[chosenOption]);
        }

        Home.Init();
    }

    private static int MenuChoices(Dictionary<int, Appointment> appointments)
    {
        int chosenOption;
        var options = new[] { 0 }.Concat(appointments.Keys).ToArray();

        Console.Clear();
        Console.WriteLine("Selecione uma consulta para editar:\n");
        foreach (var appointment in appointments)
        {
            var formatedDate = SystemCommon.FormatDateTime(appointment.Value.Date);
            Console.WriteLine($"({appointment.Key}) {appointment.Value.Specialty} para {formatedDate}");
        }

        Console.WriteLine("\nTecle (0) para voltar ao menu anterior\n");

        while (!SystemCommon.IsValidOption(options, out chosenOption))
        {
            Console.WriteLine("Opção inválida! Por favor selecione uma opção válida");
        }

        return chosenOption;
    }

    private static void ChangeAppointment(AppointmentDAL appointmentDal, Appointment appointment)
    {
        Console.Clear();
        Console.WriteLine("Escolha uma das opção abaixo para editar");
        Console.WriteLine("(1) para alterar a data.");
        Console.WriteLine("(2) para cancelar a consulta.");
        Console.WriteLine("\n(0) para voltar ao menu anterior.");

        int chosenOption;
        var options = new[] { 0, 1, 2 };
        while (!SystemCommon.IsValidOption(options, out chosenOption))
        {
            Console.WriteLine("Opção inválida escolha umas das opções válidas");
        }

        switch (chosenOption)
        {
            case 0:
                break;
            case 1:
                ChangeDate(appointmentDal, appointment);
                break;
            case 2:
                RemoveAppointment(appointmentDal, appointment);
                break;
        }
    }

    private static void ChangeDate(AppointmentDAL appointmentDal, Appointment appointment)
    {
        int chosenDate;
        var randomDates = DateRandom.GenerateListDaysAppointment(5, 10);
        var validOptions = new int[randomDates.Length];
        var datesOptions = new Dictionary<int, DateTime>();

        for (int i = 0; i < randomDates.Length; i++)
        {
            validOptions[i] = i;
            datesOptions.Add(i, randomDates[i]);
        }

        Console.Clear();
        Console.WriteLine($"Selecione uma data para agendar a consulta: {appointment.Specialty}\n");
        Console.WriteLine("Precione a tecla referente ao dia e hora disponível");
        foreach (var option in datesOptions)
        {
            var formatedDate = SystemCommon.FormatDateTime(option.Value.Date);
            Console.WriteLine($"({option.Key}) {formatedDate}");
        }

        while (!SystemCommon.IsValidOption(validOptions, out chosenDate))
        {
            Console.WriteLine("Opção inválida! Digite um número de acordo com as opção de data");
        }

        var chosenFormatedDate = SystemCommon.FormatDateTime(datesOptions[chosenDate]);
        var confirmationMessage = $"Deseja alterar a data da consulta {appointment.Specialty} para {chosenFormatedDate}";
        
        if (SystemCommon.Confirmation(confirmationMessage))
        {
            appointment.Date = datesOptions[chosenDate];
            appointmentDal.Update(appointment);

            Console.WriteLine("\nData atualizada com sucesso");
            Console.WriteLine("\nPrecione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    private static void RemoveAppointment(AppointmentDAL appointmentDal, Appointment appointment)
    {
        var formatedDate = SystemCommon.FormatDateTime(appointment.Date);
        var msg = $"Deseja realmente excluir a consulta {appointment.Specialty} para {formatedDate}";
        if (SystemCommon.Confirmation(msg))
        {
            appointmentDal.Remove(appointment);

            Console.WriteLine("\nConsulta excluída!");
            Console.WriteLine("\nPrecione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}