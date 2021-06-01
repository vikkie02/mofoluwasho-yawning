using Microsoft.EntityFrameworkCore;
using mofoluwasho_yawning.Data;
using mofoluwasho_yawning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mofoluwasho_yawning.Services
{
    public class Practice : IInterface2
    {
        private readonly ApplicationDbContext _context;
        public Practice(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserModel>> GetAll()
        {
            return await _context.UserModel.ToListAsync();
        }

        public async Task Add(UserModel Usermodel)
        {
            _context.Add(Usermodel);
            await SaveChanges();
        }

        public async Task Edit(UserModel Usermodel)
        {
            var edit = _context.UserModel.FindAsync(Usermodel.UserId);
            _context.Update(edit);
            await SaveChanges();
        }
        public async Task Delete(int id)
        {
            var delete = _context.UserModel.FindAsync(id);
            _context.Remove(delete);
            await SaveChanges();
        }
        public async Task SaveChanges()
        {
            await SaveChanges();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _context.UserModel.FindAsync(id); ;
        }
    }
}
