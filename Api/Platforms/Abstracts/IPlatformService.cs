using SentosApiLibrary.Abstracts;
using SentosApiLibrary.Api.Platforms.Models;

namespace SentosApiLibrary.Api.Platforms.Abstracts
{
    public interface IPlatformService
    {
        Task<IResult<Dictionary<string, List<Platform>>>> GetAllAsync();
    }
}
