using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Products.Models.Inputs
{
    public class UpdateProductStockInput
    {
        [JsonPropertyName("warehouse")]
        public int Warehouse { get; }

        [JsonPropertyName("stock")]
        public decimal Stock { get; }

        public UpdateProductStockInput(int warehouse, decimal stock)
        {
            Warehouse = warehouse;
            Stock = stock;
        }
    }
}
