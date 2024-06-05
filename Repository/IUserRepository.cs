using Entities;
using Project;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> Login(UserLoginDTO userLogin);
        Task<User> Register(User user);
        Task<User> updateUser(int id, User userToUpdate);
        Task<User> UserById(int id);
    }
}