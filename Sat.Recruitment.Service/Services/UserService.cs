using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Data;
using Sat.Recruitment.Domain.Models;
using Sat.Recruitment.Model.DTOs;
using Sat.Recruitment.Service.Interfaces;

namespace Sat.Recruitment.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IFunctions _functions;
        private readonly ILogger<UserService> _logger;
        private readonly IUserTypeRepository _userTypeRepository;

        public UserService(IMapper mapper, IUserRepository userRepository, IFunctions functions,
            ILogger<UserService> logger, IUserTypeRepository userTypeRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _functions = functions;
            _logger = logger;
            _userTypeRepository = userTypeRepository;
        }

        public async Task<ResultDTO> CreateUser(UserCreateDTO userDTO)
        {
            _logger.LogInformation("Entering in the method CreateUser of the UserService class");

            //get all user types
            var userTypes = await _userTypeRepository.GetAll();

            //If the userTypeId is not in the list of user types, return null
            if (!userTypes.Exists(x => x.Id == userDTO.UserTypeId))
            {
                _logger.LogInformation("The userTypeId is not in the list of user types");
                return new ResultDTO()
                {
                    StatusCode = 400,
                    Message = "The userTypeId is not in the list of user types",
                    IsSuccess = false
                };
            }


            var money = _functions.CalculateMoney(userDTO.UserTypeId, userDTO.Money);
            userDTO.Money = money;
            var user = _mapper.Map<User>(userDTO);
            var createUser = await _userRepository.CreateUser(user);
           
            if (createUser == null)
            {
                _logger.LogInformation("The user could not be created");
                return new ResultDTO()
                {
                    StatusCode = 500,
                    Message = "The user could not be created",
                    IsSuccess = false
                };
            }

            return new ResultDTO()
            {
                StatusCode = 200,
                Message = "The user was created successfully with the id: " + createUser.Id,
                IsSuccess = true
            };
        }

        public async Task<bool> CheckUser(string email)
        {
            _logger.LogInformation("Entering in the method CheckUser of the UserService class");
            var userExists = await _userRepository.UserExists(email);
            return userExists;
        }

        public async Task<List<UserTypeDTO>> GetAllUserTypes()
        {
            _logger.LogInformation("Entering in the method GetAllUserTypes of the UserService class");
            var userTypes = await _userTypeRepository.GetAll();
            return _mapper.Map<List<UserTypeDTO>>(userTypes);
        }
    }
}