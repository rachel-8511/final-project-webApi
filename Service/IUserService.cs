using Entities;
using Project;

namespace Service
{
    public interface IUserService
    {
        int CheckPasswordStregth(string pass);
        Task<User> Login(UserLoginDTO userLogin);
        Task<User> Register(User userRegister);
        Task<User> updateUser(int id, User userToUpdate);
        Task<User> UserById(int id);
    }
}