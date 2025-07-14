using SentosApiLibrary.Converters;
using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Models
{
    public class ProductPrice
    {
        [JsonPropertyName("list_price")]
        [JsonConverter(typeof(DecimalTrConverter))]
        public decimal ListPrice { get; set; }

        [JsonPropertyName("sale_price")]
        [JsonConverter(typeof(DecimalTrConverter))]
        public decimal SalePrice { get; set; }
    }
}
