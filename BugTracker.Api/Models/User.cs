using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Api.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string PasswordHash { get; set; } = string.Empty;

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; } = string.Empty;

        public bool IsActive { get; set; } = false;

        [Required(ErrorMessage = "Last login date is required")]
        public DateTime LastLoginDate { get; set; }

        [Required(ErrorMessage = "Session ID is required")]
        public string SessionId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Session expiration date is required")]
        public DateTime SessionExpiration { get; set; }

        [NotMapped]
        public bool IsSessionExpired => DateTime.UtcNow > SessionExpiration;
    }
}
