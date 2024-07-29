namespace Clinic.Model;

public class Appointment
{
    public Appointment(string specialty, string patient, DateTime date)
    {
        Id = _id++;
        Specialty = specialty;
        Patient = patient;
        Date = date;
    }

    private static int _id = 0;
    public int Id { get; set; }
    public string Specialty { get; set; }
    public string Patient { get; set; }
    public DateTime Date { get; set; }
    public bool IsCarriedOut { get; set; } = false;
}