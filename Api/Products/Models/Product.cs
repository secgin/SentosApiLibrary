using SentosApiLibrary.Converters;
using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Models
{
    public class Product
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("brand")]
        public string? Brand { get; set; }

        [JsonPropertyName("purchase_price")]
        [JsonConverter(typeof(DecimalTrConverter))]
        public decimal PurchasePrice { get; set; }

        [JsonPropertyName("sale_price")]
        [JsonConverter(typeof(DecimalTrConverter))]
        public decimal SalePrice { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("stocks")]
        public List<ProductStock> Stocks { get; set; }

        [JsonPropertyName("prices")]
        public IDictionary<string, ProductPrice> Prices { get; set; }

        [JsonPropertyName("images")]
        public List<ProductImage> Images { get; set; }

        [JsonPropertyName("variants")]
        public List<ProductVariant> Variants { get; set; }

        public Product() 
        {
            Id = 0;
            CategoryId = 0;
            Sku = string.Empty;
            Name = string.Empty;
            Brand = null;
            PurchasePrice = 0;
            SalePrice = 0;
            Currency = string.Empty;
            Stocks = [];
            Prices = new Dictionary<string, ProductPrice>();
            Images = [];
            Variants = [];
        }
    }
}
