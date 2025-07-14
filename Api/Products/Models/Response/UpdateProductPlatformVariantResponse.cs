using SentosApiLibrary.Converters;
using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Models.Response
{
    internal class UpdateProductPlatformVariantResponse
    {
        [JsonPropertyName("errors")]
        [JsonConverter(typeof(ObjectFlexiableConverter<UpdateProductPlatformVariantResponseError>))]
        public UpdateProductPlatformVariantResponseError? Errors { get; set; } = null;

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }

    internal class UpdateProductPlatformVariantResponseError
    {
        [JsonPropertyName("prices")]
        public IDictionary<string, IDictionary<string, UpdateProductPlatformVariantResponseMessage>> Prices { get; set; } = new Dictionary<string, IDictionary<string, UpdateProductPlatformVariantResponseMessage>>();
    }

    internal class UpdateProductPlatformVariantResponseMessage
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
