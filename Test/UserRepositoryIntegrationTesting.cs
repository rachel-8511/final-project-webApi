using Entities;
using Microsoft.EntityFrameworkCore;
using Project;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class UserRepositoryIntegrationTesting : IClassFixture<DatabaseFixture>
    {
        private readonly MyShop214189656Context _dbContext;
        private readonly UserRepository _userRepository;
        public UserRepositoryIntegrationTesting(DatabaseFixture databaseFixture)
        {
            _dbContext = databaseFixture.Context;
            _userRepository = new UserRepository(_dbContext);
        }
        [Fact]
        public async Task Login_ValidCredentials_ReturnsUser()
        {
            //Arrange
            var email = "test@example.com";
            var password = "password";
            User user = new User { FirstName = "ploni", LastName = "almoni", Email = email, Password = password };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            //Act
            UserLoginDTO userLoginDTO = new UserLoginDTO { Email = user.Email, Password = user.Password };
            var result = await _userRepository.Login(userLoginDTO);
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task Register_ValidUser_SavesAndReturnsUser()
        {
            // Arrange
            User user = new User { FirstName = "ploni", LastName = "almoni", Email = "test@example.com", Password = "password" };

            // Act
            var result = await _userRepository.Register(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Email, result.Email);
            Assert.Equal(user.FirstName, result.FirstName);
        }
        [Fact]
        public async Task Update_ValidIdAndUser_UpdatesAndReturnsUser()
        {

            //Arrange
            User user = new User { Email = "test@example.com", Password = "password", FirstName = "ploni", LastName = "almoni" };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            User updatedUser = new User { Email = "updatedtest@example.com", Password = "newpassword", FirstName = "UpdatedName", LastName = "UpdatedLastName" };

            // Attach the existing user to the context before updating
            _dbContext.Entry(user).State = EntityState.Detached;
            updatedUser.UserId = user.UserId; // Ensure the IDs match

            //Act
            var result = await _userRepository.updateUser(user.UserId, updatedUser);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("updatedtest@example.com", result.Email);
        }

        [Fact]
        public async Task GetById_ExistingUserId_ReturnsUser()
        {
            // Arrange
            User user = new User { FirstName = "ploni", LastName = "almoni", Email = "test@example.com", Password = "password" };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            int userId = user.UserId;

            // Act
            var result = await _userRepository.UserById(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.UserId);
        }
    }
}
