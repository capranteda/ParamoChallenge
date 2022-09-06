using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Model.DTOs;
using Sat.Recruitment.Service.Interfaces;

namespace Sat.Recruitment.Api.Controllers
{
 

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController( IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        
        
        [HttpPost]
        [Route("/")]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserCreateDTO userDto)
        {
            _logger.LogInformation("Entering in the method CreateUser of UsersController");
            
            bool userExists = await _userService.CheckUser(userDto.Email);
            if (userExists)
            {
                _logger.LogInformation("User already exists so returning 422 status code");
                return StatusCode(422, "User already exists");
            }
            
            var createUser = await _userService.CreateUser(userDto);
            if (!createUser.IsSuccess)
            {
                _logger.LogInformation("User could not be created so returning 500 status code");
                return StatusCode(createUser.StatusCode, createUser.Message);
            }
            _logger.LogInformation("User created successfully");
            return StatusCode(201, createUser.Message);
        }
        
        //Get usertypes
        [HttpGet]
        [Route("/usertypes")]
        public async Task<ActionResult<UserTypeDTO>> GetUserTypes()
        {
            _logger.LogInformation("Entering in the method GetUserTypes of UsersController");
            var userTypes = await _userService.GetAllUserTypes();
            if (userTypes == null)
            {
                _logger.LogInformation("User types could not be retrieved so returning 500 status code");
                return StatusCode(500, "Internal server error");
            }
            _logger.LogInformation("User types retrieved successfully");
            return StatusCode(200, userTypes);
        }
        

       

        
    }
}