using System;
using System.Collections.Generic;
using TodoApi.Models;
using System.Threading.Tasks;

namespace TodoApi.Data
{
    public interface IUserRepo {

        Task<bool> SaveChanges();
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id); 
        void CreateUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);

    }

}
