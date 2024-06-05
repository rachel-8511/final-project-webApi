using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> getProducts(float? minPrice, float? maxPrice, int[]? CategoriesId,string? search);
        Task<Product> ProductById(int id);
    }
}