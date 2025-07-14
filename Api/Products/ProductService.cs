using SentosApiLibrary.Abstracts;
using SentosApiLibrary.Api.Products.Abstracts;
using SentosApiLibrary.Api.Products.Models;
using SentosApiLibrary.Api.Products.Models.Inputs;
using SentosApiLibrary.Api.Products.Models.Response;

namespace SentosApiLibrary.Api.Products
{
    internal class ProductService: IProductService
    {
        private readonly IHttpClientService _httpClientService;

        public ProductService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IResult<Product>> CreateAsync(CreateProductInput input)
        {
            var response = await _httpClientService.PostAsync<CreateProductResponse>("/products", input);
            if (response.IsFail)
                return Result<Product>.Fail(response.Code, response.Message);

            if (response.Data == null || response.Data.Product == null)
            {
                string message = "Response is null";
                
                if (response.Data != null)
                {
                    if (response.Data.Message != null)
                        message = response.Data.Message;
                    else if (response.Data.Errors != null)
                    {
                        if (response.Data.Errors.Variants.Count > 0)
                            message = string.Join(", ", response.Data.Errors.Variants.Select(v => v));
                    }
                }


                return Result<Product>.Fail(response.Code, message);
            }

            return Result<Product>.Success(response.Data.Product);
        }

        public async Task<IPaginationResult<Product>> GetAllAsync(ProductFilterInput input)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new("page", input.Page.ToString()),
                new("pageSize", input.Size.ToString())
            };

            if (!string.IsNullOrWhiteSpace(input.Sku))            
                parameters.Add(new KeyValuePair<string, string>("sku", input.Sku));

            var response = await _httpClientService.GetAsync<PaginationResponse<Product>>("/products", parameters);
            if (response.IsFail)
                return PaginationResult<Product>.Fail(response.Code, response.Message);

            return PaginationResult<Product>.Success(response.Data.Data, response.Data.Page, response.Data.Size, response.Data.TotalElements, response.Data.TotalPages);
        }

        public async Task<IResult> UpdatePlatformVariants(int productId, List<UpdateProductPlatformVariantInput> inputs)
        {
            var response = await _httpClientService.PutAsync<UpdateProductPlatformVariantResponse>("/products/" + productId + "/platform-variants", inputs);
            if (response.IsFail)
                return Result.Fail(response.Code, response.Message);

            if (response.Data == null)
            {
                string message = "Response is null";

                if (response.Data != null)
                {
                    if (response.Data.Message != null)
                        message = response.Data.Message;
                    else if (response.Data.Errors != null)
                    {
                        //if (response.Data.Errors.Prices.Count > 0)
                        //    message = string.Join(", ", response.Data.Errors.Price.Select(v => v));
                    }
                }


                return Result.Fail(response.Code, message);
            }

            return Result.Success();
        }

        public async Task<IResult<Product>> UpdatePriceAndStockAsync(int productId, UpdateProductInput input)
        {
            var response = await _httpClientService.PutAsync<UpdateProductResponse>("/products/" + productId, input);
            if (response.IsFail)
                return Result<Product>.Fail(response.Code, response.Message);

            if (response.Data == null || response.Data.Product == null)
            {
                string message = "Response is null";

                if (response.Data != null)
                {
                    if (response.Data.Message != null)
                        message = response.Data.Message;
                    else if (response.Data.Errors != null)
                    {
                        if (response.Data.Errors.Price.Count > 0)
                            message = string.Join(", ", response.Data.Errors.Price.Select(v => v));
                    }
                }


                return Result<Product>.Fail(response.Code, message);
            }

            return Result<Product>.Success(response.Data.Product);
        }
    }
}
