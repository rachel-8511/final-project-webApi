using System.Text.Json;
using Entities;
using Microsoft.Extensions.Logging;
using Project;
using Repository;

namespace Service
{
    public class OrderService : IOrderService

    {

        private IOrderRepository _orderRepository;
        private IProductService _productService;
        private readonly ILogger<OrderService> _logger;
        public OrderService(IOrderRepository orderRepository, IProductService productService, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _productService = productService;
            _logger = logger;
        }
        public async Task<Order> addOrder(Order oredrPost)
        {
           
               double sum = 0;
               foreach (OrderItem o in oredrPost.OrderItems)
                {
                    
                    Product product = await _productService.ProductById(o.ProductId);
                    sum += product.Price * o.Quantity;
                }
                if (sum != oredrPost.OrderSum)
                {
                    _logger.LogError($"user {oredrPost.UserId}  tried perchasing with a difffrent price {oredrPost.OrderSum} instead of {sum}");
                    _logger.LogInformation($"user {oredrPost.UserId}  tried perchasing with a difffrent price {oredrPost.OrderSum} instead of {sum}");
                }
                oredrPost.OrderSum = sum;
                return await _orderRepository.addOrder(oredrPost);
           
        }
    }
}
