using Microsoft.EntityFrameworkCore;
using RailwayPortalClassLibrary;

namespace InternalAPI
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Role adminRole = new Role { Id = 1, Name = "Admin" };
            Role employeeRole = new Role { Id = 2, Name = "Employee" };
            Role instructorRole = new Role { Id = 3, Name = "Instructor" };
            Role engineerRole = new Role { Id = 4, Name = "Engineer" };

            User admin = new User { Id = 1, Email = "admin", Password = "12345678", RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole });
            modelBuilder.Entity<Role>().HasData(new Role[] { employeeRole });
            modelBuilder.Entity<Role>().HasData(new Role[] { instructorRole });
            modelBuilder.Entity<Role>().HasData(new Role[] { engineerRole });

            modelBuilder.Entity<User>().HasData(new User[] { admin });
            base.OnModelCreating(modelBuilder);
        }
    }
}
