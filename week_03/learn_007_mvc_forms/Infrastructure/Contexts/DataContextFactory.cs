using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var connectionString = DatabaseHelper.GetSQLServerDatabaseConnectionString();
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        
        optionsBuilder.UseSqlServer(connectionString)
            .UseLazyLoadingProxies();
        
        return new DataContext(optionsBuilder.Options);
    }
}