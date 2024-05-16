using Microsoft.EntityFrameworkCore;
using PizzaOrderAPI.Exceptions;
using PizzaOrderAPI.Interfaces;
using PizzaOrderAPI.Models;
using PizzaOrderAPI.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace PizzaOrderAPI.services
{
    public class UserLoginService : IUserLoginServices
    {

        private readonly IRepository<int, UserDetails> _userDetailsRepo;
        private readonly IRepository<int, User> _userRepo;
        private readonly ITokenServices _tokenServices;

        public UserLoginService(IRepository<int, UserDetails> userDetailsRepo, IRepository<int, User> userRepo,ITokenServices tokenServices)
        {
            _userRepo = userRepo;
            _userDetailsRepo = userDetailsRepo;
            _tokenServices = tokenServices;
        }
        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            try 
            {
                var userDB = await _userDetailsRepo.Get(loginDTO.UserId);
                if (userDB == null)
                {
                    throw new UnauthorizedUserException("Invalid username or password");
                }
                HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
                var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
                bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
                if (isPasswordSame)
                {
                    var user = await _userRepo.Get(loginDTO.UserId);
                    LoginReturnDTO loginReturnDTO = MapEmployeeToLoginReturn(user);
                    return loginReturnDTO;
                }
                throw new UnauthorizedUserException("Invalid username or password");
            }
            catch(Exception ex)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            
        }

        private LoginReturnDTO MapEmployeeToLoginReturn(User user)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.EmployeeID = user.UserId;
            returnDTO.Role = user.Role ?? "User";
            returnDTO.Token = _tokenServices.GenerateToken(user);
            return returnDTO;
        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<User> Register(UserDTO userDTO)
        {
            User user = null;
            UserDetails userDetail = null;
            try
            {
                user = userDTO;
                userDetail = MapEmployeeUserDTOToUser(userDTO);

                var existingUsers = await _userRepo.Get();
                var result = existingUsers.FirstOrDefault(u => u.Email == user.Email);
                if (result != null)
                {
                    throw new UserAlreadyExistsException();
                }

                user = await _userRepo.Add(user);
                userDetail.UserId = user.UserId;
                userDetail = await _userDetailsRepo.Add(userDetail);
                ((UserDTO)user).Password = string.Empty;
                return user;
            }
            catch (UserAlreadyExistsException ex)
            {
                throw new UserAlreadyExistsException();
            }
            catch (Exception) { }
            if (user != null)
                await RevertUserInsert(user);
            if (userDetail != null && user == null)
                await RevertUserDetailsInsert(userDetail);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private async Task RevertUserDetailsInsert(UserDetails userDetails)
        {
            await _userDetailsRepo.Delete(userDetails.UserId);
        }

        private async Task RevertUserInsert(User user)
        {
            await _userRepo.Delete(user.UserId);
        }

        private UserDetails MapEmployeeUserDTOToUser(UserDTO userDTO)
        {
            UserDetails userDetails = new UserDetails();
            userDetails.UserId = userDTO.UserId;
            HMACSHA512 hMACSHA = new HMACSHA512();
            userDetails.PasswordHashKey = hMACSHA.Key;
            userDetails.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
            return userDetails;
        }
    }
}
