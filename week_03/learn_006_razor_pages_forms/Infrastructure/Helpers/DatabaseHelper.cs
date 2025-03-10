namespace Infrastructure.Helpers;

public class DatabaseHelper
{
    public static string GetSQLServerDatabaseConnectionString()
    {
        var connectionString = $@"
            Server=localhost;
            Database=sql_database;
            Trusted_Connection=False;
            Persist Security Info=False;
            Encrypt=False;
            User ID=Querzion;
            Password=Scam2014;
            Connect Timeout=30;
        ";
        return connectionString;
    }
}