using Microsoft.EntityFrameworkCore;

namespace PortalGate.Models.DatabaseContext
{
    public class RailroadsContext : DbContext
    {
        public DbSet<Railroad> RailroadList { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<UnitStartPageURI> UnitStartPageUries { get; set; }

        public RailroadsContext(DbContextOptions<RailroadsContext> options) : base(options)
        { }
    }
}