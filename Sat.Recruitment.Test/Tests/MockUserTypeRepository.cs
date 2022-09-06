using System.Collections.Generic;
using System.Threading.Tasks;
using Sat.Recruitment.Data;
using Sat.Recruitment.Domain.Models;

namespace Sat.Recruitment.Test.Tests
{
    public class MockUserTypeRepository: IUserTypeRepository
    {
        public Task<List<UserType>> GetAll()
        {
            var list = new List<UserType>
            {
                new UserType
                {
                    Name = "Normal",
                    Id = 1
                },
                new UserType
                {
                    Name = "SuperUser",
                    Id = 2
                },
                new UserType
                {
                    Name = "Premium",
                    Id = 3
                    
                }
            };
            
            return Task.FromResult(list);
        }
    }
}