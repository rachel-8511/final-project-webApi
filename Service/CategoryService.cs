using System.Text.Json;
using Entities;
using Project;
using Repository;

namespace Service
{
    public class CategoryService : ICategoryService

    {

        ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<Category>> getCategories()
        {
            
                return await _categoryRepository.getCategories();
           
        }
    }
}
