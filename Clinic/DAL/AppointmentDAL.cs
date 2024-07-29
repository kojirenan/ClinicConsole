using Clinic.Model;

namespace Clinic.DAL;

public static class AppointmentDAL
{
    public static List<Appointment> Appointments { get; set; } = new ()
    {
        new Appointment("Dermatologista", "Renan Koji", DateTime.Now.AddHours(10)),
        new Appointment("Ortopedista", "Renan Koji", DateTime.Now.AddDays(-5)),
        new Appointment("Clínico Geral", "Renan Koji", DateTime.Now.AddMonths(1)),
        new Appointment("Nutricionista", "Renan Koji", DateTime.Now.AddHours(-26)),
    };
}