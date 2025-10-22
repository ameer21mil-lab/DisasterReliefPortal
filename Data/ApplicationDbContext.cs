using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using YourNamespace.Models;
using Task = YourNamespace.Models.Task;

namespace YourNamespace.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> // Ensure you use your custom user class
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Your DbSet properties here
        public DbSet<Task> Tasks { get; set; }
        public DbSet<IncidentReport> IncidentReports { get; set; }
        public DbSet<Donation> Donations { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Task>(entity =>
            {
                entity.ToTable("Tasks");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000);

                entity.Property(e => e.Progress)
                    .HasMaxLength(50);

                entity.Property(e => e.AssignedToUserId)
                    .HasMaxLength(450);

                // Foreign key relationship
                entity.HasOne(e => e.AssignedToUser)
                    .WithMany()
                    .HasForeignKey(e => e.AssignedToUserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
