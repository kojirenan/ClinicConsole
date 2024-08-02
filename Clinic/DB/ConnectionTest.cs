
using Microsoft.Data.Sqlite;

namespace Clinic.DAL;

public class ConnectionTest
{
    private const string connectionString = "Data Source=/Users/renankoji/Desktop/Clinic/clinic.sqlite;";

    public SqliteConnection getConnection()
    {
        return new SqliteConnection(connectionString);
    }
}