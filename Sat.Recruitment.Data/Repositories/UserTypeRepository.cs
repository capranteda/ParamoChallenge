using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Domain.Models;

namespace Sat.Recruitment.Data.Repositories
{
    public class UserTypeRepository :IUserTypeRepository
    {
        private readonly ApplicationDBContext _context;

        public UserTypeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        
        public Task<List<UserType>> GetAll()
        {
            return _context.UserTypes.ToListAsync();
        }
    }
}