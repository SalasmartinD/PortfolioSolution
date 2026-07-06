using System.Text.Json.Serialization;

namespace Portfolio.Shared.Models
{
    public class Project
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("short_description")]
        public string ShortDescription { get; set; } = string.Empty;

        [JsonPropertyName("technologies")]
        public string Technologies { get; set; } = string.Empty;

        [JsonPropertyName("github_url")]
        public string GitHubUrl { get; set; } = string.Empty;

        [JsonPropertyName("live_demo_url")]
        public string? LiveDemoUrl { get; set; } = string.Empty;

        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; set; } = string.Empty;

        [JsonPropertyName("priority")]
        public int Priority { get; set; } = 1;

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }
    }
}