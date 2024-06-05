using Entities;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        MyShop214189656Context _myShop214189656;
        public OrderRepository(MyShop214189656Context myShop214189656)
        {
            _myShop214189656 = myShop214189656;
        }
        public async Task<Order> addOrder(Order orderPost)
        {
            
                await _myShop214189656.Orders.AddAsync(orderPost);
                await _myShop214189656.SaveChangesAsync();

                return orderPost;
           

        }
    }
}
