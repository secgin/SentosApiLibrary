using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SentosApiLibrary.Converters
{
    internal class DecimalTrConverter: JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? stringValue;

            if (reader.TokenType == JsonTokenType.String)
            {
                stringValue = reader.GetString();
            }
            else if (reader.TokenType == JsonTokenType.Number)
            {
                // Sayı değerini doğrudan decimal olarak oku
                if (reader.TryGetDecimal(out var numberValue))
                {
                    return numberValue;
                }

                // Sayı olarak okuyamazsa fallback olarak stringe çevirip devam et
                stringValue = reader.GetDouble().ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                throw new JsonException($"Beklenmeyen JSON token tipi: {reader.TokenType}");
            }

            return ConvertToDecimal(stringValue) ?? 0;
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(new CultureInfo("tr-TR")));
        }

        private static decimal? ConvertToDecimal(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            input = input.Trim();

            // Ondalık ayracı olarak "." veya "," kullanan durumu tespit edelim
            int lastDotIndex = input.LastIndexOf('.');
            int lastCommaIndex = input.LastIndexOf(',');

            string detectedDecimalSeparator;
            if (lastDotIndex > lastCommaIndex)
                detectedDecimalSeparator = ".";
            else if (lastCommaIndex > lastDotIndex)
                detectedDecimalSeparator = ",";
            else
                detectedDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator; // Tek bir ayraç varsa sisteminkini baz al

            // Sistem ondalık ayracını alalım
            string systemDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            // Önce binlik ayracı olan karakterleri temizleyelim
            if (detectedDecimalSeparator == ".")
            {
                // Nokta ondalık ise, tüm virgüller binlik ayracı olur ve silinir
                input = input.Replace(",", "");
            }
            else if (detectedDecimalSeparator == ",")
            {
                // Virgül ondalık ise, tüm noktalar binlik ayracı olur ve silinir
                input = input.Replace(".", "");
            }

            // Ardından ondalık ayracı sisteminkine çevirelim
            if (detectedDecimalSeparator != systemDecimalSeparator)
            {
                input = input.Replace(detectedDecimalSeparator, systemDecimalSeparator);
            }

            // Sayıya çevirme
            if (decimal.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out decimal result))
            {
                return result;
            }

            return null;
        }
    }
}
