using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PCStore.Infrastrucure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contragent>()
                .HasIndex(c => c.CustomerNumber)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Computer> Computers { get; set; }

        public DbSet<Laptop> Laptops { get; set; }

        public DbSet<Display> Displays { get; set; }

        public DbSet<Deal> Deals { get; set; }

        public DbSet<Contragent> Contragents { get; set; }

        public DbSet<DealSubject> DealSubjects { get; set; }
    }
}