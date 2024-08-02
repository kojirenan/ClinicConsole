using Clinic.Model;
using Microsoft.EntityFrameworkCore;

namespace Clinic.DAL;

public class ClinicContext : DbContext
{
    public DbSet<Appointment> Appointments { get; set; }
    private const string connectionString = "Data Source=/Users/renankoji/Desktop/Clinic/clinic.sqlite;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString);
    }
}