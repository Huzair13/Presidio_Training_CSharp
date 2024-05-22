using Microsoft.AspNetCore.Mvc;
using PizzaOrderAPI.Models.DTOs;
using PizzaOrderAPI.Models;
using PizzaOrderAPI.Interfaces;

namespace PizzaOrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLoginServices _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserLoginServices userService,ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }


        [HttpPost("Login")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<User>> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var result = await _userService.Login(userLoginDTO);
                _logger.LogInformation("Login successful for user: {UserID}", userLoginDTO.UserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login failed for user: {UserID}", userLoginDTO.UserId);
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
        [HttpPost("Register")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> Register(UserDTO userDTO)
        {
            try
            {
                User result = await _userService.Register(userDTO);
                _logger.LogInformation("Registration successful for user: {UserId}", userDTO.UserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registration failed for user: {UserId}", userDTO.UserId);
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }
    }
}
