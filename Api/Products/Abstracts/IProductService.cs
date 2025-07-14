using SentosApiLibrary.Abstracts;
using SentosApiLibrary.Api.Products.Models;
using SentosApiLibrary.Api.Products.Models.Inputs;

namespace SentosApiLibrary.Api.Products.Abstracts
{
    public interface IProductService
    {
        Task<IPaginationResult<Product>> GetAllAsync(ProductFilterInput input);

        Task<IResult<Product>> CreateAsync(CreateProductInput input);

        Task<IResult<Product>> UpdatePriceAndStockAsync(int productId, UpdateProductInput input); 

        Task<IResult> UpdatePlatformVariants(int productId, List<UpdateProductPlatformVariantInput> inputs);
    }
}
