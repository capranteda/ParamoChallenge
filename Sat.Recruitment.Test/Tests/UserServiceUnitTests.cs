using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Sat.Recruitment.Data;
using Sat.Recruitment.Domain.Models;
using Sat.Recruitment.Model.DTOs;
using Sat.Recruitment.Service.Interfaces;
using Sat.Recruitment.Service.MappingProfiles;
using Sat.Recruitment.Service.Services;
using Sat.Recruitment.Test.Repositories;
using Xunit;

namespace Sat.Recruitment.Test.Tests
{
    public class UserServiceUnitTests
    {
        private UserCreateDTO userDTO = new UserCreateDTO
        {
            Name = "Chris",
            Email = "chris@gmail.com",
            Address = "123 Main St",
            Phone = "123456789",
            UserTypeId = 1,
            Money = 100
        };

        private User userIn = new User
        {
            Name = "Chris",
            Email = "chris@gmail.com",
            Address = "123 Main St",
            Phone = "123456789",
            UserTypeId = 1,
            Money = 100
        };


        [Fact]
        public async void UserCreationTest()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperProfiles()); });
            var mapper = mockMapper.CreateMapper();

            var mockLogger = new Mock<ILogger<UserService>>();
            var mockFunctions = new Mock<IFunctions>();

            mockFunctions.Setup(x => x.CalculateMoney(userIn.UserTypeId, userIn.Money)).Returns(180);
            var mockUserRepository = new MockUserRepository();
            var mockUserTypeRepository = new MockUserTypeRepository();
            var service = new UserService(mapper, mockUserRepository, mockFunctions.Object, mockLogger.Object, mockUserTypeRepository);

            var result = await service.CreateUser(userDTO);

            Assert.True(result.StatusCode == 200, "User creation failed");
        }

        [Fact]
        public async void UserNotExists()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperProfiles()); });
            var mapper = mockMapper.CreateMapper();

            var mockLogger = new Mock<ILogger<UserService>>();
            var mockFunctions = new Mock<IFunctions>();

            var mockUserRepository = new MockUserRepositoryNegative();
            var mockUserTypeRepository = new MockUserTypeRepository();

            var service = new UserService(mapper, mockUserRepository, mockFunctions.Object, mockLogger.Object, mockUserTypeRepository);

            var result = await service.CheckUser(userDTO.Email);

            Assert.True(result, "The user should not exist");
        }

        [Fact]
        public async void UserCouldntBeCreated()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperProfiles()); });
            var mapper = mockMapper.CreateMapper();

            var mockLogger = new Mock<ILogger<UserService>>();
            var mockFunctions = new Mock<IFunctions>();

            var mockUserRepository = new MockUserRepositoryNegative();
            var mockUserTypeRepository = new MockUserTypeRepository();

            var service = new UserService(mapper, mockUserRepository, mockFunctions.Object, mockLogger.Object, mockUserTypeRepository);

            var result = await service.CreateUser(userDTO);

            Assert.True( !result.IsSuccess, "The user should not be created");
        }


        [Fact]
        public async void GetAllUserTypesTest()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperProfiles()); });
            var mapper = mockMapper.CreateMapper();

            var mockLogger = new Mock<ILogger<UserService>>();
            var mockFunctions = new Mock<IFunctions>();

            var mockUserRepository = new MockUserRepository();
            var mockUserTypeRepository = new MockUserTypeRepository();

            var service = new UserService(mapper, mockUserRepository, mockFunctions.Object, mockLogger.Object, mockUserTypeRepository);

            var result = await service.GetAllUserTypes();
            
            Assert.True(result.Count == 3, "The user types should be 3");
            Assert.True( result.GetType() == typeof(List<UserTypeDTO>), "The result should be a list of user types");
        }
        
    }
}