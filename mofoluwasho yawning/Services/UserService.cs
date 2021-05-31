using Microsoft.EntityFrameworkCore;
using mofoluwasho_yawning.Data;
using mofoluwasho_yawning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mofoluwasho_yawning.Services
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserModel>> GetAll()
        {
            return await _context.UserModel.ToListAsync();
        }
        public async Task Delete(int id)
        {
            var del = _context.UserModel.FindAsync(id);
            _context.Remove(del);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
