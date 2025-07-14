using SentosApiLibrary.Abstracts;
using SentosApiLibrary.Api.Categories.Abstracts;
using SentosApiLibrary.Api.Categories.Models;
using SentosApiLibrary.Api.Categories.Models.Inputs;

namespace SentosApiLibrary.MockApi
{
    internal class MockCategoryService : ICategoryService
    {
        private readonly JsonDataStore<Category> _store;

        private int _lastId = 0;

        public MockCategoryService(IConfig config)
        {
            _store = new JsonDataStore<Category>(Path.Combine(config.TestStoragePath, "Categories.json"));
            _lastId = GetLastId(_store.GetAll());
        }

        public async Task<IResult<Category>> Create(CreateCategoryInput input)
        {
            if (input.ParentId == 0)
            {
                var category = new Category
                {
                    Id = ++_lastId,
                    Name = input.Name,
                    ParentId = 0
                };
                _store.Add(category);

                return await Task.FromResult(Result<Category>.Success(category));
            }

            var parentCategory = FindCategory(_store.GetAll(), input.ParentId);
            if (parentCategory != null)
            {
                var subcategory = parentCategory.SubCategories.FirstOrDefault(c => c.Name.Equals(input.Name, StringComparison.CurrentCultureIgnoreCase));
                if (subcategory == null)
                {
                    subcategory = new Category
                    {
                        Id = ++_lastId,
                        Name = input.Name,
                        ParentId = parentCategory.Id
                    };

                    parentCategory.SubCategories.Add(subcategory);
                    _store.Save();
                }

                return Result<Category>.Success(subcategory);
            }

            return await Task.FromResult(Result<Category>.Fail("Kategori oluşturulamadı"));
        }

        public async Task<IResult<List<Category>>> GetAllAsync()
        {
            return await Task.FromResult(Result<List<Category>>.Success(_store.GetAll()));
        }

        private Category? FindCategory(List<Category> categories, int id)
        {
            foreach (var category in categories)
            {
                if (category.Id == id)
                    return category;

                if (category.SubCategories.Count > 0)
                {
                    var childCategory = FindCategory(category.SubCategories, id);
                    if (childCategory != null)
                        return childCategory;
                }
            }

            return null;
        }

        private int GetLastId(List<Category> categories)
        {
            int categoryId = 0;

            foreach (var category in categories)
            {
                if (category.Id > categoryId)
                    categoryId = category.Id;

                if (category.SubCategories.Count > 0)
                {
                    int subCategoryId = GetLastId(category.SubCategories);
                    if (subCategoryId > categoryId)
                        categoryId = subCategoryId;
                }
            }

            return categoryId;
        }
    }
}
