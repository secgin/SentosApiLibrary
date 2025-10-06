using SentosApiLibrary.Abstracts;
using SentosApiLibrary.Api.Categories;
using SentosApiLibrary.Api.Categories.Abstracts;
using SentosApiLibrary.Api.Platforms;
using SentosApiLibrary.Api.Platforms.Abstracts;
using SentosApiLibrary.Api.Products;
using SentosApiLibrary.Api.Products.Abstracts;
using SentosApiLibrary.Api.Warehouses;
using SentosApiLibrary.Api.Warehouses.Abstracts;
using SentosApiLibrary.MockApi;

namespace SentosApiLibrary
{
    public class SentosClient : ISentosClient
    {
        private readonly IConfig _config;

        private readonly IHttpClientService _httpClientService;

        private readonly Lazy<IProductService> _productService;

        private readonly Lazy<ICategoryService> _categoryService;

        private readonly Lazy<IWarehouseService> _warehouseService;

        private readonly Lazy<IPlatformService> _platformService;

        public SentosClient(IConfig config)
        {
            _config = config;
            _httpClientService = new HttpClientService(_config);

            if (config.IsTestMode)
            {
                _categoryService = new Lazy<ICategoryService>(() => new MockCategoryService(_config));
                _warehouseService = new Lazy<IWarehouseService>(() => new MockWarehouseService());
                _productService = new Lazy<IProductService>(() => new MockProductService(_config));          
                _platformService = new Lazy<IPlatformService>(() => new MockPlatformService());
            }
            else
            {
                _categoryService = new Lazy<ICategoryService>(() => new CategoryService(_httpClientService));
                _warehouseService = new Lazy<IWarehouseService>(() => new WarehouseService(_httpClientService));
                _productService = new Lazy<IProductService>(() => new ProductService(_httpClientService));
                _platformService = new Lazy<IPlatformService>(() => new PlatformService(_httpClientService));   
            }
        }

        public ICategoryService Category => _categoryService.Value;

        public IWarehouseService Warehouse => _warehouseService.Value;

        public IProductService Product => _productService.Value;

        public IPlatformService Platform => _platformService.Value;
    }
}
