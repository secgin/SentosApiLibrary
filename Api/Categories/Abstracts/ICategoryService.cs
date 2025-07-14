using SentosApiLibrary.Abstracts;
using SentosApiLibrary.Api.Categories.Models;
using SentosApiLibrary.Api.Categories.Models.Inputs;

namespace SentosApiLibrary.Api.Categories.Abstracts
{
    public interface ICategoryService
    {
        Task<IResult<List<Category>>> GetAllAsync();

        Task<IResult<Category>> Create(CreateCategoryInput input);
    }
}
