using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BugTracker.Api.Models
{
    public class Project : BaseEntity
    {
        [Required(ErrorMessage = "Project name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Project name must be between 3 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Range(typeof(DateTime), "StartDate", "9999-12-31", ErrorMessage = "End date cannot be before start date")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Project status is required")]
        public Status Status { get; set; }

        [Required(ErrorMessage = "Priority is required")]
        public Priority Priority { get; set; }

        // Project progress tracking (automatically calculated)
        [Range(0, 100, ErrorMessage = "Progress must be between 0 and 100")]
        public int Progress => TotalBugs > 0 ? (int)((ResolvedBugs / (double)TotalBugs) * 100) : 0;

        // Automatic calculation of total bugs
        public int TotalBugs => Bugs?.Count ?? 0;

        // Automatic calculation of resolved bugs
        public int ResolvedBugs => Bugs?.Count(bug => bug.Status == Status.Fixed) ?? 0;

        // Project configuration
        public bool SendNotifications { get; set; } = true;
        public int NotificationThreshold { get; set; } = 5; // Number of bugs before notification

        public virtual ICollection<User> TeamMembers { get; set; } = new List<User>();
        public virtual ICollection<Bug> Bugs { get; set; } = new List<Bug>();
    }
}
