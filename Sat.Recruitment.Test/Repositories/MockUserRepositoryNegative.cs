using System.Threading.Tasks;
using Sat.Recruitment.Data;
using Sat.Recruitment.Domain.Models;

namespace Sat.Recruitment.Test.Repositories
{
    public class MockUserRepositoryNegative: IUserRepository
    {
        public async Task<User> CreateUser(User user)
        {
            return null;
        }

        public async  Task<bool> UserExists(string email)
        {
            return await Task.Run(() => true);

        }
    }
}
   