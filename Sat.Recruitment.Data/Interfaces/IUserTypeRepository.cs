using System.Collections.Generic;
using System.Threading.Tasks;
using Sat.Recruitment.Domain.Models;

namespace Sat.Recruitment.Data
{
    public interface IUserTypeRepository
    {
       public Task<List<UserType>> GetAll();
    }
}