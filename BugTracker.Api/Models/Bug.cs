using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Api.Models
{
    public class Bug : BaseEntity
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        public Status Status { get; set; }

        [Required(ErrorMessage = "Priority is required")]
        public Priority Priority { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public BugType Type { get; set; }

        [Required(ErrorMessage = "Severity is required")]
        public BugSeverity Severity { get; set; }

        public string? StepsToReproduce { get; set; }
        public string? ExpectedResult { get; set; }
        public string? ActualResult { get; set; }
        public string? Environment { get; set; }

        [Required(ErrorMessage = "Project is required")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; } = null!;

        public int? AssignedToId { get; set; }
        [ForeignKey("AssignedToId")]
        public virtual User? AssignedTo { get; set; }

        public int? ReportedById { get; set; }
        [ForeignKey("ReportedById")]
        public virtual User? ReportedBy { get; set; }

        [ForeignKey("LastModifiedById")]
        public virtual User? LastModifiedBy { get; set; }

        public virtual ICollection<BugComment> Comments { get; set; } = new List<BugComment>();
        public virtual ICollection<BugAttachment> Attachments { get; set; } = new List<BugAttachment>();
    }

    public enum BugType
    {
        [Display(Name = "Bug")]
        Bug = 1,
        [Display(Name = "Feature")]
        Feature = 2,
        [Display(Name = "Enhancement")]
        Enhancement = 3,
        [Display(Name = "Task")]
        Task = 4
    }

    public enum BugSeverity
    {
        [Display(Name = "Trivial")]
        Trivial = 1,
        [Display(Name = "Minor")]
        Minor = 2,
        [Display(Name = "Major")]
        Major = 3,
        [Display(Name = "Critical")]
        Critical = 4,
        [Display(Name = "Blocker")]
        Blocker = 5
    }
}
