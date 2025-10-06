using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Platforms.Models
{
    public class Platform
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
