using SentosApiLibrary.Abstracts;
using SentosApiLibrary.Api.Warehouses.Abstracts;
using SentosApiLibrary.Api.Warehouses.Models;

namespace SentosApiLibrary.MockApi
{
    internal class MockWarehouseService : IWarehouseService
    {
        public async Task<IResult<List<Warehouse>>> GetAllAsync()
        {
            return await Task.FromResult(Result<List<Warehouse>>.Success([
                new Warehouse {
                    Id = 1,
                    Name = "MERKEZ"
                },
                 new Warehouse {
                    Id = 2,
                    Name = "DEPO"
                }
                ]));
        }
    }
}
