namespace SentosApiLibrary.Api.Products.Models.Inputs
{
    public class ProductFilterInput
    {
        public string? Sku { get; set; }

        public int Size { get; set; } = 100;

        public int Page { get; set; }
    }
}
