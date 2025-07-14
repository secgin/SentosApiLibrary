using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Models.Inputs
{
    public class UpdateProductPlatformVariantInput
    {
        [JsonPropertyName("sku")]
        public string Sku { get; }

        [JsonPropertyName("prices")]
        public IDictionary<string, UpdateProductPriceInput> Prices { get; }

        [JsonPropertyName("stocks")]
        public IList<UpdateProductStockInput> Stocks { get; }

        public UpdateProductPlatformVariantInput(string sku, IList<UpdateProductStockInput> stocks)
        {
            Sku = sku;
            Prices = new Dictionary<string, UpdateProductPriceInput>();
            Stocks = stocks;
        }
    }
}
