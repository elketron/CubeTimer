using Microsoft.EntityFrameworkCore;

namespace CubeTimerData.Models;

public class CubeTimerContext : DbContext
{
    public CubeTimerContext(DbContextOptions<CubeTimerContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Solves> Solves { get; set; }
}
