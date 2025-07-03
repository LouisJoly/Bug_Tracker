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
                .HasMany(project => project.TeamMembers)
                .WithMany(user => user.Projects)
                .UsingEntity(j => j.ToTable("ProjectTeamMembers"));

            modelBuilder.Entity<Project>()
                .HasMany(project => project.Bugs)
                .WithOne(bug => bug.Project)
                .HasForeignKey(bug => bug.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Bug
            modelBuilder.Entity<Bug>()
                .HasOne(bug => bug.AssignedTo)
                .WithMany(user => user.AssignedBugs)
                .HasForeignKey(bug => bug.AssignedToId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Bug>()
                .HasOne(bug => bug.ReportedBy)
                .WithMany(user => user.ReportedBugs)
                .HasForeignKey(bug => bug.ReportedById)
                .OnDelete(DeleteBehavior.SetNull);

            // Configure BugComment
            modelBuilder.Entity<BugComment>()
                .HasOne(comment => comment.User)
                .WithMany(user => user.Comments)
                .HasForeignKey(comment => comment.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<BugComment>()
                .HasOne(comment => comment.Bug)
                .WithMany(bug => bug.Comments)
                .HasForeignKey(comment => comment.BugId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure BugAttachment
            modelBuilder.Entity<BugAttachment>()
                .HasOne(attachment => attachment.UploadedBy)
                .WithMany(user => user.Attachments)
                .HasForeignKey(attachment => attachment.UploadedById)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<BugAttachment>()
                .HasOne(attachment => attachment.Bug)
                .WithMany(bug => bug.Attachments)
                .HasForeignKey(attachment => attachment.BugId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
