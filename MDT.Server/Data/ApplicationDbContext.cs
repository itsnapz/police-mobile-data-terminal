using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MDT.Server.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Citizen> Citizens { get; set; }
    public DbSet<Car> Cars { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}