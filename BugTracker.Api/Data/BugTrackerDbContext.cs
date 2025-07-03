using Microsoft.EntityFrameworkCore;
using BugTracker.Api.Models;

namespace BugTracker.Api.Data
{
    public class BugTrackerDbContext : DbContext
    {
        public BugTrackerDbContext(DbContextOptions<BugTrackerDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<BugComment> BugComments { get; set; }
        public DbSet<BugAttachment> BugAttachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User
            modelBuilder.Entity<User>()
                .HasIndex(user => user.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique();

            // Configure Project
            modelBuilder.Entity<Project>()
                .HasMany(p => p.TeamMembers)
                .WithMany(u => u.Projects)
                .UsingEntity(j => j.ToTable("ProjectTeamMembers"));

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Bugs)
                .WithOne(b => b.Project)
                .HasForeignKey(b => b.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Bug
            modelBuilder.Entity<Bug>()
                .HasOne(b => b.AssignedTo)
                .WithMany(u => u.AssignedBugs)
                .HasForeignKey(b => b.AssignedToId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Bug>()
                .HasOne(b => b.ReportedBy)
                .WithMany(u => u.ReportedBugs)
                .HasForeignKey(b => b.ReportedById)
                .OnDelete(DeleteBehavior.SetNull);

            // Configure BugComment
            modelBuilder.Entity<BugComment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<BugComment>()
                .HasOne(c => c.Bug)
                .WithMany(b => b.Comments)
                .HasForeignKey(c => c.BugId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure BugAttachment
            modelBuilder.Entity<BugAttachment>()
                .HasOne(a => a.UploadedBy)
                .WithMany(u => u.Attachments)
                .HasForeignKey(a => a.UploadedById)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<BugAttachment>()
                .HasOne(a => a.Bug)
                .WithMany(b => b.Attachments)
                .HasForeignKey(a => a.BugId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
