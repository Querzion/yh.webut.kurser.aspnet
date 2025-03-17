using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{

    #region ChatGPT Addition (NOT ACTIVE)

        /// <summary>
        /// 
        /// ~/RiderProjects/yh.webut.kurser.aspnet/week_04/learn_012_custom_identity.db.context/Presentation.WebApp.Separated git:[main]
        /// dotnet-ef migrations add CustomerAddedFromDataProject --context DataContext
        ///
        /// Build started...
        /// Build succeeded.
        ///     The Entity Framework tools version '9.0.1' is older than that of the runtime '9.0.3'. Update the tools for the latest features and bug fixes. See https://aka.ms/AAc1fbw for more information.
        /// Your target project 'Presentation.WebApp.Separated' doesn't match your migrations assembly 'Data'. Either change your target project or change your migrations assembly.
        ///     Change your migrations assembly by using DbContextOptionsBuilder. E.g. options.UseSqlServer(connection, b => b.MigrationsAssembly("Presentation.WebApp.Separated")). By default, the migrations assembly is the assembly containing the DbContext.
        ///     Change your target project to the migrations project by using the Package Manager Console's Default project drop-down list, or by executing "dotnet ef" from the directory containing the migrations project.
        /// </summary>
        /// <param name="optionsBuilder"></param>
    
        // Did NOT work.
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         
        //         optionsBuilder.UseSqlite("Data Source=./Data/Contexts/sqlite.db", b => 
        //             b.MigrationsAssembly("Data"));
        //     }
        // }

    #endregion
    
    public virtual DbSet<CustomerEntity> Customers { get; set; }
}