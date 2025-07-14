using SentosApiLibrary.Abstracts;
using SentosApiLibrary.Api.Warehouses.Models;

namespace SentosApiLibrary.Api.Warehouses.Abstracts
{
    public interface IWarehouseService
    {
        Task<IResult<List<Warehouse>>> GetAllAsync();
    }
}
