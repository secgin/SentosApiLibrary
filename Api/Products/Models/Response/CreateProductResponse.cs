using SentosApiLibrary.Api.Products.Converters;
using SentosApiLibrary.Converters;
using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Models.Response
{
    internal class CreateProductResponse
    {
        [JsonPropertyName("errors")]
        [JsonConverter(typeof(ObjectFlexiableConverter<CreateProductResponseError>))]
        public CreateProductResponseError? Errors { get; set; } = null;

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("product")]
        [JsonConverter(typeof(ProductFlexibleConverter))]
        public Product? Product { get; set; }
    }

    internal class CreateProductResponseError
    {
        [JsonPropertyName("variants")]
        public List<string> Variants { get; set; } = [];
    }
}
