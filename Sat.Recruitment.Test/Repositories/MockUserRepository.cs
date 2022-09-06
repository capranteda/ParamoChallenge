using System.Threading.Tasks;
using Sat.Recruitment.Data;
using Sat.Recruitment.Domain.Models;

namespace Sat.Recruitment.Test.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        public async Task<User> CreateUser(User user)
        {
            var newUser = new User()
            {
                Id = 1,
                Name = "Chris",
                Email = "chris@gmail.com",
                Address = "123 Main St",
                Phone = "123456789",
                UserType = new UserType()
                {
                    Id = 1,
                    Name = "Normal",
                },
                UserTypeId = 1,
                Money = 180
            };


            return await Task.Run(() => newUser);
        }

        public async  Task<bool> UserExists(string email)
        {
            return await Task.Run(() => false);

        }
    }
}