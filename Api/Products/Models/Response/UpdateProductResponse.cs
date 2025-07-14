using SentosApiLibrary.Api.Products.Converters;
using SentosApiLibrary.Converters;
using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Models.Response
{
    internal class UpdateProductResponse
    {
        [JsonPropertyName("errors")]
        [JsonConverter(typeof(ObjectFlexiableConverter<UpdateProductResponseError>))]
        public UpdateProductResponseError? Errors { get; set; } = null;

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("product")]
        [JsonConverter(typeof(ProductFlexibleConverter))]
        public Product? Product { get; set; }
    }

    internal class UpdateProductResponseError
    {
        [JsonPropertyName("price")]
        public List<string> Price { get; set; } = [];
    }
}
