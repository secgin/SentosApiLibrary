using SentosApiLibrary.Api.Products.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Converters
{
    internal class ProductFlexibleConverter : JsonConverter<Product?>
    {
        public override Product? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Eğer product boş dizi ise: []
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                reader.Read(); // [
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    return null;
                }

                throw new JsonException("Unexpected array with values for 'product'");
            }

            // Eğer product nesne ise: {}
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var product = JsonSerializer.Deserialize<Product>(ref reader, options);
                return product;
            }

            // Hiçbiri değilse hata
            throw new JsonException($"Unexpected token type: {reader.TokenType}");
        }

        public override void Write(Utf8JsonWriter writer, Product? value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
