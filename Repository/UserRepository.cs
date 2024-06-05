using Entities;
using Microsoft.EntityFrameworkCore;
using Project;
using System.Text.Json;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        MyShop214189656Context _myShop214189656;
        public UserRepository(MyShop214189656Context myShop214189656)
        {
            _myShop214189656 = myShop214189656;
        }
        public async Task<User> UserById(int id)
        {
            
                User user = await _myShop214189656.Users.FindAsync(id);
                if (user.UserId == id)
                    return user;
                 
                return null;
                
           

        }

        public async Task<User> Login(UserLoginDTO userLogin)
        {
            
                User user= await _myShop214189656.Users.Where(user => user.Email == userLogin.Email && user.Password == userLogin.Password).FirstOrDefaultAsync();
                if(user!=null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
           
        }

        public async Task<User> Register(User userRegister)
        {
            
                await _myShop214189656.Users.AddAsync(userRegister);
                await _myShop214189656.SaveChangesAsync();
              
                return await UserById(userRegister.UserId);

            
        }

        public async Task<User> updateUser(int id, User userToUpdate)
        {
           
                if (userToUpdate == null)
                    return null;
                userToUpdate.UserId = id;
                _myShop214189656.Update(userToUpdate);
                await _myShop214189656.SaveChangesAsync();
                return userToUpdate;
         
        }
    }
}
