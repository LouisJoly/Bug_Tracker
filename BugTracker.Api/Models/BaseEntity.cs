using System.Text.Json.Serialization;

namespace BugTracker.Api.Models
{
    public abstract class BaseEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        [JsonInclude]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; } = false;

        [JsonPropertyName("lastModifiedById")]
        [JsonInclude]
        public int? LastModifiedById { get; set; } 
    }
}
