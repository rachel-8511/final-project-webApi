using Entities;

namespace Service
{
    public interface IProductService
    {
        Task<List<Product>> getProducts(float? minPrice, float? maxPrice, int[]? CategoriesId,string? search);
        Task<Product> ProductById(int id);
    }
}