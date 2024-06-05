using Entities;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        MyShop214189656Context _myShop214189656;
        public CategoryRepository(MyShop214189656Context myShop214189656)
        {
            _myShop214189656 = myShop214189656;
        }
        public async Task<List<Category>> getCategories()
        {
           
                return await _myShop214189656.Categories.ToListAsync();
          

        }
    }
}
