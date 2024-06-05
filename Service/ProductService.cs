using System.Text.Json;
using Entities;
using Project;
using Repository;

namespace Service
{
    public class ProductService : IProductService

    {

        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> getProducts(float? minPrice, float? maxPrice, int[]? CategoriesId,string? search)
        {
          
                return await _productRepository.getProducts(minPrice, maxPrice, CategoriesId, search);
          
           
        }
        public async Task<Product> ProductById(int id)
        {
            
              return await _productRepository.ProductById(id);

        }

    }
}
