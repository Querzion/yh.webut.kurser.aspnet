using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions options) : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
    
    public virtual DbSet<MemberAddressEntity> MemberAddresses { get; set; }
    public virtual DbSet<MemberImageEntity> MemberImages { get; set; }
}