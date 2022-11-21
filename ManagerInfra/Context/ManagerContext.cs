using ManagerDomain.Entities;
using ManagerInfra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ManagerInfra.Context;

public class ManagerContext : DbContext
{
    public ManagerContext()
    {
        
    }
    public ManagerContext(DbContextOptions options) :base (options){}

    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserMap());
    }
    
}