using Infrastructure.Entities;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(DatabaseHelper.GetSQLServerDatabaseConnectionString())
                .UseLazyLoadingProxies();
        }
    }
    
    public DbSet<ClientEntity> Clients { get; set; } = null!;
    public DbSet<StatusEntity> Statuses { get; set; } = null!;
    public DbSet<ProjectEntity> Projects { get; set; } = null!;
}