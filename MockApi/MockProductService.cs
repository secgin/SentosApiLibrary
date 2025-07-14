using SentosApiLibrary.Abstracts;
using SentosApiLibrary.Api.Products.Abstracts;
using SentosApiLibrary.Api.Products.Models;
using SentosApiLibrary.Api.Products.Models.Inputs;

namespace SentosApiLibrary.MockApi
{
    internal class MockProductService : IProductService
    {
        private readonly JsonDataStore<Product> _store;

        private readonly IdGenerator _idGenerator;

        public MockProductService(IConfig config)
        {
            _store = new JsonDataStore<Product>(Path.Combine(config.TestStoragePath, "Products.json"));
            _idGenerator = new IdGenerator(config.TestStoragePath);
        }

        public async Task<IResult<Product>> CreateAsync(CreateProductInput input)
        {
            var product = new Product
            {
                Id = _idGenerator.GetNextProductId(),
                CategoryId = input.CategoryId,
                Sku = input.Sku,
                Name = input.Name,
                Brand = input.Brand,
                PurchasePrice = input.PurchasePrice,
                SalePrice = input.SalePrice,
                Currency = input.Currency,
                Stocks = input.Stocks,
                Prices = input.Prices,
                Images = input.Images,
                Variants = input.Variants
            };
            _store.Add(product);

            await Task.Delay(200);
            return await Task.FromResult(Result<Product>.Success(product));
        }

        public async Task<IPaginationResult<Product>> GetAllAsync(ProductFilterInput input)
        {
            var products = _store.GetAll();

            var filteredProducts = string.IsNullOrWhiteSpace(input.Sku)
                ? products
                : products.Where(p => p.Sku == input.Sku).ToList();

            var page = input.Page <= 0 ? 1 : input.Page;
            var pageSize = input.Size;

            var data = filteredProducts.Skip((page - 1) * input.Size).Take(pageSize).ToList();           
            var totalElements = filteredProducts.Count;
            int totalPages = (int)Math.Ceiling((double)totalElements / pageSize);

            return await Task.FromResult(PaginationResult<Product>.Success(data, page, pageSize, totalElements, totalPages));
        }

        public async Task<IResult> UpdatePlatformVariants(int productId, List<UpdateProductPlatformVariantInput> inputs)
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(1000);
                return await Task.FromResult(Result.Success());
            });
        }

        public async Task<IResult<Product>> UpdatePriceAndStockAsync(int productId, UpdateProductInput input)
        {
            return await Task.Run(() =>
            {
                var product = _store.Find(p => p.Id == productId);
                if (product == null)
                    return Result<Product>.Fail("Not found product");

                product.PurchasePrice = input.PurchasePrice;
                product.SalePrice = input.SalePrice;

                if (input.Stocks != null && input.Stocks.Count > 0)
                {
                    foreach (var productStock in product.Stocks)
                    {
                        var inputStock = input.Stocks.FirstOrDefault(x => x.Warehouse == productStock.Warehouse);
                        if (inputStock != null)
                            productStock.Warehouse = inputStock.Warehouse;
                    }
                }

                if (input.Prices != null && input.Prices.Count > 0)
                {
                    foreach (var productPrice in product.Prices)
                    {
                        if (input.Prices.TryGetValue(productPrice.Key, out UpdateProductPriceInput? updateProductPriceInput) && updateProductPriceInput != null)
                        {
                            productPrice.Value.SalePrice = updateProductPriceInput.SalePrice;
                            productPrice.Value.ListPrice = updateProductPriceInput.ListPrice;
                        }
                    }
                }

                if (input.Variants != null && input.Variants.Count > 0)
                {
                    foreach (var productVariant in product.Variants)
                    {
                        var inputVariant = input.Variants.FirstOrDefault(v => v.Sku == productVariant.VariantSku);
                        if (inputVariant == null)
                            continue;

                        if (inputVariant.Stocks != null)
                        {
                            foreach (var productVariantStock in productVariant.Stocks)
                            {
                                var inputVariantStock = inputVariant.Stocks.FirstOrDefault(vs => vs.Warehouse == productVariantStock.Warehouse);
                                if (inputVariantStock == null)
                                    continue;

                                productVariantStock.Stock = (int)inputVariantStock.Stock;
                            }
                        }
                    }
                }

                _store.Save();

                return Result<Product>.Success(product);
            });
        }
    }
}
