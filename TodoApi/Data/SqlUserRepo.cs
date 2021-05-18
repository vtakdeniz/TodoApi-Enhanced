using System;
using System.Collections.Generic;
using TodoApi.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly TodoApiContext _context;

        public SqlUserRepo(TodoApiContext context) {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if (user==null) {
                throw new ArgumentNullException();
            }

              _context.users.Add(user);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            
            _context.users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.users.Include(u => u.user_Has_jobs).ThenInclude(s => s.job).ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.users.Include(u => u.user_Has_jobs).ThenInclude(s => s.job).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public  async Task<bool> SaveChanges()
        {
            return  await _context.SaveChangesAsync() >= 0;
        }

        public void UpdateUser(User user)
        {
            // NOTHING
        }

       
    }
}
