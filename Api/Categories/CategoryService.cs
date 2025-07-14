using SentosApiLibrary.Abstracts;
using SentosApiLibrary.Api.Categories.Abstracts;
using SentosApiLibrary.Api.Categories.Models;
using SentosApiLibrary.Api.Categories.Models.Inputs;

namespace SentosApiLibrary.Api.Categories
{
    internal class CategoryService : ICategoryService
    {
        private readonly IHttpClientService _httpClientService;

        public CategoryService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IResult<Category>> Create(CreateCategoryInput input)
        {
            return await _httpClientService.PostAsync<Category>("/categories", input);
        }

        public async Task<IResult<List<Category>>> GetAllAsync()
        {
            return await _httpClientService.GetAsync<List<Category>>("/categories");
        }
    }
}
