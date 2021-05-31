using mofoluwasho_yawning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mofoluwasho_yawning.Services
{
    public interface IUser
    {
        Task <List<UserModel>> GetAll();
        Task Delete(int id);
        Task SaveChanges();

    }
}
