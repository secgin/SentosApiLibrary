using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Models
{
    public class ProductVariant
    {
        [JsonPropertyName("sku")]
        public string VariantSku { get; set; }

        [JsonPropertyName("barcode")]
        public string Barcode { get; set; }

        [JsonPropertyName("model")]
        public ProductVariantModel Model { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("stocks")]
        public List<ProductStock> Stocks { get; set; }

        [JsonPropertyName("images")]
        public List<ProductImage> Images { get; set; }

        public ProductVariant()
        {
            VariantSku = string.Empty;
            Barcode = string.Empty;
            Model = new ProductVariantModel();
            Color = string.Empty;
            Stocks = [];
            Images = [];
        }
    }
}
