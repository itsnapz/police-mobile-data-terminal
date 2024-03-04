using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MDT.Server.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Citizen> Citizens { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Record> Records { get; set; }
    public DbSet<Fine> Fines { get; set; }
    public DbSet<Warrant> Warrants { get; set; }
    public DbSet<Station> Stations { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}