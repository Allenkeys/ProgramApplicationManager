using Microsoft.EntityFrameworkCore;
using ProgramApplicationManager.Domain.Entities;

namespace ProgramApplicationManager.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToContainer("users");

            modelBuilder.Entity<ProgramDetail>()
                .HasPartitionKey(x => x.ProgramId)
                .ToContainer("programs");

            modelBuilder.Entity<Application>()
                .HasPartitionKey(x => x.ProgramId)
                .ToContainer("applications");

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ProgramDetail> Progams { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
    }
}
