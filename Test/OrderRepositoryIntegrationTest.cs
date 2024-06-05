using Entities;
using Repository;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class OrderRepositoryIntegrationTest : IClassFixture<DatabaseFixture>
    {
        private readonly MyShop214189656Context _dbContext;
        private readonly OrderRepository _orderRepository;

        public OrderRepositoryIntegrationTest(DatabaseFixture databaseFixture)
        {
            _dbContext = databaseFixture.Context;
            _orderRepository = new OrderRepository(_dbContext);
        }

        [Fact]
        public async Task CreateOrder_ValidOrder_ReturnsOrder()
        {
            // Arrange
            var user = new User { FirstName = "Test", LastName = "User", Email = "testuser@example.com", Password = "password" };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var order = new Order
            {
                OrderDate = DateTime.UtcNow,
                OrderSum = 200.00,
                UserId = user.UserId
            };

            // Act
            var result = await _orderRepository.addOrder(order);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(order.OrderDate, result.OrderDate);
            Assert.Equal(order.OrderSum, result.OrderSum);
            Assert.Equal(order.UserId, result.UserId);
        }
    }
}