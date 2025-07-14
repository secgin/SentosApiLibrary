using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Models
{
    public class ProductVariantModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public string Value { get; set; } = string.Empty;
    }
}
