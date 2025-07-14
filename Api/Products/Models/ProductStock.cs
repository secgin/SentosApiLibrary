using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Models
{
    public class ProductStock
    {
        [JsonPropertyName("warehouse")]
        public int Warehouse { get; set; }

        [JsonPropertyName("stock")]
        public int Stock { get; set; }
    }
}
