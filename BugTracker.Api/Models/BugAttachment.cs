using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Api.Models
{
    public class BugAttachment : BaseEntity
    {
        [Required(ErrorMessage = "Filename is required")]
        [StringLength(255, ErrorMessage = "Filename cannot exceed 255 characters")]
        public string Filename { get; set; } = string.Empty;

        [Required(ErrorMessage = "File type is required")]
        [StringLength(50, ErrorMessage = "File type cannot exceed 50 characters")]
        public string FileType { get; set; } = string.Empty;

        [Required(ErrorMessage = "File size is required")]
        public long FileSize { get; set; }

        [Required(ErrorMessage = "File data is required")]
        public byte[] FileData { get; set; } = Array.Empty<byte>();

        [Required(ErrorMessage = "Bug is required")]
        public int BugId { get; set; }
        [ForeignKey("BugId")]
        public virtual Bug Bug { get; set; } = null!;

        [Required(ErrorMessage = "Uploaded by is required")]
        public int UploadedById { get; set; }
        [ForeignKey("UploadedById")]
        public virtual User UploadedBy { get; set; } = null!;
    }
}
