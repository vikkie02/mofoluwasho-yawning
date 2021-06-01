using mofoluwasho_yawning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mofoluwasho_yawning.Services
{
    public interface IInterface2
    {
        Task<List<UserModel>> GetAll();
        Task <UserModel> GetById (int id);
        Task Add(UserModel UserModel);
        Task Delete(int id);
        Task Edit(UserModel Usermodel);
        Task SaveChanges();


        //Task<List<UserModel>> GetAll();

    }
}
