using Entities;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        MyShop214189656Context _myShop214189656;
        public ProductRepository(MyShop214189656Context myShop214189656)
        {
            _myShop214189656 = myShop214189656;
        }
        public async Task<List<Product>> getProducts(float? minPrice, float? maxPrice, int[]? CategoriesId,string? search)
        {
          
                var query = _myShop214189656.Products.Where(product =>
                (search == null ? true : (product.Description.Contains(search) || product.ProductName.Contains(search)))
                && (minPrice == null ? true :(product.Price >= minPrice))
                && (maxPrice == null ? true :(product.Price<=maxPrice))
                &&(CategoriesId.Length==0?true:CategoriesId.Contains(product.CategoryId)))
                .OrderBy(product => product.Price);
                List<Product> products = await query.ToListAsync();
                return products;
           

        }

        public async Task<Product> ProductById(int id)
        {
           
                Product product = await _myShop214189656.Products.FindAsync(id);
                if (product.ProductId == id)
                    return product;

                return null;

          

        }
    }
}
