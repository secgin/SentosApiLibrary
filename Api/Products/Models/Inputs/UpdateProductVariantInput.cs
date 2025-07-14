using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Models.Inputs
{
    public class UpdateProductVariantInput
    {
        [JsonPropertyName("sku")]
        public string Sku { get; }

        [JsonPropertyName("stocks")]
        public IList<UpdateProductStockInput>? Stocks { get; }

        public UpdateProductVariantInput(
            string sku,
            IList<UpdateProductStockInput>? stocks)
        {
            Sku = sku;
            Stocks = stocks;
        }
    }
}
