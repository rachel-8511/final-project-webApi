
using AutoMapper;
using DTOs;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly ILogger<UsersController> _Ilogger;
 

        public UsersController(IUserService userService, IMapper mapper, ILogger<UsersController> Ilogger)
        {
            _userService = userService;
            _mapper = mapper;
            _Ilogger = Ilogger;
        }
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            
                User user = await _userService.UserById(id);
                UserDTO userDto = _mapper.Map<User, UserDTO>(user);


                if (userDto != null)
                  return Ok(userDto);
                    
               return NoContent();
           
        }



        // POST: UsersController/login
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserDTO>> Login([FromBody] UserLoginDTO userLogin)
        {
            

                User user = await _userService.Login(userLogin);
                _Ilogger.LogInformation($"login attempted with User name ,{user.Email} and password {user.Password}");

                UserDTO userToReturn = _mapper.Map<User, UserDTO>(user);


                if (userToReturn != null)
                    return Ok(userToReturn);

                return Unauthorized();

           
        }



        // POST: UsersController/register
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserDTO>> Register([FromBody] UserDTO userRegister)
        {
           
                int result = _userService.CheckPasswordStregth(userRegister.Password);
                if (result > 2)
                {
                    User userToRegister = _mapper.Map<UserDTO, User>(userRegister);
                    User user = await _userService.Register(userToRegister);
                    UserDTO userToReturn = _mapper.Map<User, UserDTO>(user);

                    if (userToReturn != null)
                    { 
                        return Ok(userToReturn);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                    return NoContent();

        }

        // PUT: UsersController/register
        [HttpPut("{id}")]
        
        public async Task<ActionResult<UserDTO>> updateUser(int id,[FromBody] UserDTO userToUpdate)
        {
           
                User user = _mapper.Map<UserDTO, User>(userToUpdate);

                int result = _userService.CheckPasswordStregth(userToUpdate.Password);
                if (result > 2)
                {
                    User updateUser = await _userService.updateUser(id, user);
                    UserDTO userToReturn = _mapper.Map<User, UserDTO>(updateUser);

                    if (userToReturn != null)
                    {
                        return Ok(userToReturn);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return NoContent();
                }
           
        }

        [HttpPost]
        [Route("passStrength")]
        public ActionResult<int> checkPassStrength([FromBody] User user)
        {
            return Ok(_userService.CheckPasswordStregth(user.Password));
        }

    }
}
