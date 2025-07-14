using System.Text.Json.Serialization;

namespace SentosApiLibrary
{
    public class Response
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }    
    }
}
