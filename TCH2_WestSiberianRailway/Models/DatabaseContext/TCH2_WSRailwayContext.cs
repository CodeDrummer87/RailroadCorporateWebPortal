using Microsoft.EntityFrameworkCore;
using RailwayPortalClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCH2_WestSiberianRailway.Models.DatabaseContext
{
    public class TCH2_WSRailwayContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<User> Users { get; set; }

        public TCH2_WSRailwayContext(DbContextOptions<TCH2_WSRailwayContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Role adminRole = new Role { Id = 1, Name = "admin" };
            User admin = new User { Id = 1, Email = "admin", Password = "12345678", RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole });
            modelBuilder.Entity<User>().HasData(new User[] { admin });
            base.OnModelCreating(modelBuilder);
        }
    }
}
