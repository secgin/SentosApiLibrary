using System.Text.Json;
using System.Text.Json.Serialization;

namespace SentosApiLibrary.Converters
{
    internal class ObjectFlexiableConverter<T> : JsonConverter<T?>
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Eğer product boş dizi ise: []
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                reader.Read(); // [
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    return default;
                }

                throw new JsonException("Unexpected array with values for 'product'");
            }

            // Eğer product nesne ise: {}
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var product = JsonSerializer.Deserialize<T>(ref reader, options);
                return product;
            }

            // Hiçbiri değilse hata
            throw new JsonException($"Unexpected token type: {reader.TokenType}");
        }

        public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
