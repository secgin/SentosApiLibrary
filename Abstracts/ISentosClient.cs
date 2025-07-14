using SentosApiLibrary.Api.Categories.Abstracts;
using SentosApiLibrary.Api.Products.Abstracts;
using SentosApiLibrary.Api.Warehouses.Abstracts;

namespace SentosApiLibrary.Abstracts
{
    public interface ISentosClient
    {
        ICategoryService Category { get; }

        IWarehouseService Warehouse { get; }

        IProductService Product { get; }
    }
}
