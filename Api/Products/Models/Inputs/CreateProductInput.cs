using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Models.Inputs
{
    public class CreateProductInput
    {
        [JsonPropertyName("sku")]
        public required string Sku { get; set; }

        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("invoice_name")]
        public required string InvoiceName { get; set; }

        [JsonPropertyName("brand")]
        public string? Brand { get; set; }

        [JsonPropertyName("description")]
        public required string Description { get; set; }

        [JsonPropertyName("currency")]
        public required string Currency { get; set; }

        [JsonPropertyName("purchase_price")]
        public decimal PurchasePrice { get; set; }

        [JsonPropertyName("sale_price")]
        public decimal SalePrice { get; set; }

        [JsonPropertyName("vat_rate")]
        public int VatRate { get; set; }

        [JsonPropertyName("volumetric_weight")]
        public int VolumetricWeight { get; set; }

        [JsonPropertyName("barcode")]
        public string? Barcode { get; set; }

        [JsonPropertyName("description_detail")]
        public required string DescriptionDetail { get; set; }

        [JsonPropertyName("stocks")]
        public List<ProductStock> Stocks { get; set; } = [];

        [JsonPropertyName("images")]
        public List<ProductImage> Images { get; set; } = [];

        [JsonPropertyName("prices")]
        public Dictionary<string, ProductPrice> Prices { get; set; } = [];

        [JsonPropertyName("variants")]
        public List<ProductVariant> Variants { get; set; } = [];
    }
}
