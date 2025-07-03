using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Api.Models
{
    public class BugComment : BaseEntity
    {
        [Required(ErrorMessage = "Content is required")]
        [StringLength(1000, ErrorMessage = "Content cannot exceed 1000 characters")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = "User is required")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;

        [Required(ErrorMessage = "Bug is required")]
        public int BugId { get; set; }
        [ForeignKey("BugId")]
        public virtual Bug Bug { get; set; } = null!;
    }
}
