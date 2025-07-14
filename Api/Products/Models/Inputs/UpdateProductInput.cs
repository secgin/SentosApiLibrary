using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Models.Inputs
{
    public class UpdateProductInput
    {
        [JsonPropertyName("purchase_price")]
        public decimal PurchasePrice { get; }

        [JsonPropertyName("sale_price")]
        public decimal SalePrice { get; }

        [JsonPropertyName("prices")]
        public IDictionary<string, UpdateProductPriceInput>? Prices { get; }

        [JsonPropertyName("stocks")]
        public IList<UpdateProductStockInput>? Stocks { get; }

        [JsonPropertyName("variants")]
        public IList<UpdateProductVariantInput> Variants { get; set; } = [];

        public UpdateProductInput(
            decimal salePrice,
            decimal purchasePrice,             
            IDictionary<string, UpdateProductPriceInput>? 
            prices, List<UpdateProductStockInput>? stocks)
        {
            SalePrice = salePrice;
            PurchasePrice = purchasePrice;
            Prices = prices;
            Stocks = stocks;
        }      
    }
}
