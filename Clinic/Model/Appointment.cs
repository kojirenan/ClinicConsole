namespace Clinic.Model;

public class Appointment
{
    public Appointment(string specialty, string patient, DateTime date)
    {
        Specialty = specialty;
        Patient = patient;
        Date = date;
    }

    public int Id { get; set; }
    public string Specialty { get; set; }
    public string Patient { get; set; }
    public DateTime Date { get; set; }
    public bool IsCarriedOut { get; set; } = false;
}