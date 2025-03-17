using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Presentation.WebApp.Data.Entities;

namespace Presentation.WebApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public virtual DbSet<CustomerEntity> Customers { get; set; }
}