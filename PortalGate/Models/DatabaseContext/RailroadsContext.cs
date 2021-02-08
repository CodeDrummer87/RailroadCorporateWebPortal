using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGate.Models.DatabaseContext
{
    public class RailroadsContext : DbContext
    {
        public DbSet<Railroad> Railroads { get; set; }

        public RailroadsContext(DbContextOptions<RailroadsContext> options) : base(options)
        { }
    }
}
