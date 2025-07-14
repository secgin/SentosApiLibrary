using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Models.Inputs
{
    public class UpdateProductPriceInput
    {
        [JsonPropertyName("sale_price")]
        public decimal SalePrice { get; }

        [JsonPropertyName("list_price")]
        public decimal ListPrice { get; }

        public UpdateProductPriceInput(decimal salePrice, decimal listPrice)
        {
            SalePrice = salePrice;
            ListPrice = listPrice;
        }
    }
}
