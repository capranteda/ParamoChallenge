using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Domain.Models;
using System.Diagnostics.CodeAnalysis;

namespace Sat.Recruitment.Data.Repositories
{
    [ExcludeFromCodeCoverage]
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        
        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UserExists(string email)
        {
            var userExists = await _context.Users.AnyAsync(x => x.Email == email);
            return userExists;
            
        }
    }
}