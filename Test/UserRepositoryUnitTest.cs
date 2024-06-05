using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Project;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class UserRepositoryUnitTest
    {
        [Fact]
        public async Task GetById_ExistingUser_ReturnsUser()
        {
            // Arrange
            User user = new User { FirstName = "Test", LastName = "Test", Email = "test@example.com", Password = "password", };

            var mockContext = new Mock<MyShop214189656Context>();
            mockContext.Setup(x => x.Users.FindAsync(user.UserId)).ReturnsAsync(user);

            var userRepository = new UserRepository(mockContext.Object);

            // Act
            var result = await userRepository.UserById(user.UserId);

            // Assert
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task Register_ValidUser_ReturnsUser()
        {
            // Arrange
            var user = new User {FirstName = "Test", LastName = "Test", Email = "test2@example.com", Password = "password" };

            var users = new List<User>();
            var mockContext = new Mock<MyShop214189656Context>();
            mockContext.Setup(x => x.Users.FindAsync(user.UserId)).ReturnsAsync(user);

            var userRepository = new UserRepository(mockContext.Object);

            // Act
            var result = await userRepository.Register(user);

            // Assert
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task Login_ValidCredentials_ReturnsUser()
        {
            // Arrange
            var user = new User { Email = "login@example.com", Password = "password" };

            var mockContext = new Mock<MyShop214189656Context>();
            var users = new List<User> { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var userLogin = new UserLoginDTO { Email = user.Email, Password = user.Password };

            // Act
            var result = await userRepository.Login(userLogin);

            // Assert
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task Update_ExistingUser_UpdatesUser()
        {
            // Arrange
            int userId = 1;
            var existingUser = new User { UserId = userId, FirstName = "olduser", LastName = "olduser", Email="a@b.c", Password = "oldpassword" };
            var updatedUser = new User { UserId = userId, FirstName = "newuser", LastName = "newuser", Email="a@b.c", Password = "newpassword" };

            var mockDbContext = new Mock<MyShop214189656Context>();
            var users = new List<User>() { existingUser };
            mockDbContext.Setup(x => x.Users.FindAsync(userId)).ReturnsAsync(existingUser);

            var userRepository = new UserRepository(mockDbContext.Object);

            // Act
            var result = await userRepository.updateUser(userId, updatedUser);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedUser.Email, result.Email);
            Assert.Equal(updatedUser.Password, result.Password);
        }
    }
}