using SentosApiLibrary.Abstracts;
using SentosApiLibrary.Api.Platforms.Abstracts;
using SentosApiLibrary.Api.Platforms.Models;

namespace SentosApiLibrary.Api.Platforms
{
    internal class PlatformService : IPlatformService
    {
        private readonly IHttpClientService _httpClientService;

        public PlatformService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IResult<Dictionary<string, List<Platform>>>> GetAllAsync()
        {
            return await _httpClientService.GetAsync<Dictionary<string, List<Platform>>>("/platforms");
        }
    }
}
