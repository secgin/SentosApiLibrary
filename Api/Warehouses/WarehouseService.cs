using SentosApiLibrary.Abstracts;
using SentosApiLibrary.Api.Warehouses.Abstracts;
using SentosApiLibrary.Api.Warehouses.Models;

namespace SentosApiLibrary.Api.Warehouses
{
    internal class WarehouseService : IWarehouseService
    {
        private readonly IHttpClientService _httpClientService;

        public WarehouseService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IResult<List<Warehouse>>> GetAllAsync()
        {
            return await _httpClientService.GetAsync<List<Warehouse>>("/warehouses");
        }
    }
}
