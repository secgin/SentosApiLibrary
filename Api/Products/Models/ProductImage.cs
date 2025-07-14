using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Models
{
    public class ProductImage
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }
}
