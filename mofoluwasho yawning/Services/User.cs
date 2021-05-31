using Microsoft.EntityFrameworkCore;
using mofoluwasho_yawning.Data;
using mofoluwasho_yawning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mofoluwasho_yawning.Services
{
    public class User : IUser
    {
        private readonly ApplicationDbContext _context;
        public User(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserModel>> GetAll()
        {
            return await _context.UserModel.ToListAsync();
        }
    }
}
