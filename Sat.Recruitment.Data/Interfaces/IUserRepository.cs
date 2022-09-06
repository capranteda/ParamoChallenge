using System.Threading.Tasks;
using Sat.Recruitment.Domain.Models;

namespace Sat.Recruitment.Data
{
    public interface IUserRepository
    {
        public Task<User> CreateUser(User user);
        
        public Task<bool> UserExists(string email);
        
        
    }
}