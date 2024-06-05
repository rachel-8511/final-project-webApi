using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> addOrder(Order orderPost);
    }
}