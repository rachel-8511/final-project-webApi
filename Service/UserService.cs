using System.Text.Json;
using Entities;
using Project;
using Repository;

namespace Service
{
    public class UserService : IUserService

    {

        IUserRepository _userRepository;
        public  UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> UserById(int id)
        {
           
                return await _userRepository.UserById(id);
           

        }

        public async Task<User> Login(UserLoginDTO userLogin)
        {
           
                return await _userRepository.Login(userLogin);

          
        }

        public async Task<User> Register(User userRegister)
        {
          
                return await _userRepository.Register(userRegister);
           
        }

        public async Task<User> updateUser(int id, User userToUpdate)
        {
           

                return await _userRepository.updateUser(id, userToUpdate);
           
        }

        public int CheckPasswordStregth(string pass)
        {
           
                var result = Zxcvbn.Core.EvaluatePassword(pass);
                return result.Score;
           

        }
    }
}
