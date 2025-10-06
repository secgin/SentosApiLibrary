using SentosApiLibrary.Abstracts;
using SentosApiLibrary.Api.Platforms.Abstracts;
using SentosApiLibrary.Api.Platforms.Models;

namespace SentosApiLibrary.MockApi
{
    internal class MockPlatformService : IPlatformService
    {
        public Task<IResult<Dictionary<string, List<Platform>>>> GetAllAsync()
        {
            return Task.FromResult(Result< Dictionary<string, List<Platform>>>.Success(new Dictionary<string, List<Platform>> {
                {
                    "e-commerce", new List<Platform> {
                        new Platform {
                            Id = 1,
                            Name = "Shopify"
                        },
                        new Platform {
                            Id = 2,
                            Name = "WooCommerce"
                        },
                        new Platform {
                            Id = 3,
                            Name = "Magento"
                        }
                    }
                }
            }));
        }
    }
}
