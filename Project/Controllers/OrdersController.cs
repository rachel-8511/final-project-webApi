using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private IOrderService _orderService;
        private IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> post([FromBody] OrderDTO orderPost)
        {
                Order regularOrder = _mapper.Map<OrderDTO, Order>(orderPost);
                Order order = await _orderService.addOrder(regularOrder);
                OrderDTO orderToReturn = _mapper.Map<Order, OrderDTO>(order);
                if (orderToReturn != null)
                  return Ok(orderToReturn);
                    
               return BadRequest();
                
            

        }



    }
}
