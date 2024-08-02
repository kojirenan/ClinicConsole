using Clinic.Model;

namespace Clinic.DAL;

public class AppointmentDAL
{
    private readonly ClinicContext _context;

    public AppointmentDAL(ClinicContext context)
    {
        _context = context;
    }

    public IEnumerable<Appointment> List()
    {
        return _context.Appointments.ToList();
    }

    public void Add(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        _context.SaveChanges();
    }

    public void Update(Appointment appointment)
    {
        _context.Appointments.Update(appointment);
        _context.SaveChanges();
    }

    public void Remove(Appointment appointment)
    {
        _context.Appointments.Remove(appointment);
        _context.SaveChanges();
    }
}