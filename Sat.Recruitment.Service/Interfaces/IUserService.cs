using System.Collections.Generic;
using System.Threading.Tasks;
using Sat.Recruitment.Model.DTOs;

namespace Sat.Recruitment.Service.Interfaces
{
    public interface IUserService
    {
        //create 
        public Task<ResultDTO> CreateUser(UserCreateDTO user);

        public Task<bool> CheckUser(string email);

        public Task<List<UserTypeDTO>> GetAllUserTypes();
    }
}