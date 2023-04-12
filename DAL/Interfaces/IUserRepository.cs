using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAll();

        public Task<User?> GetById(int id);

        public Task<User?> GetByEmail(string email);

        public Task<User?> GetByPseudo(string pseudo);

        public Task<User?> Add(User user);

        public Task<bool> Delete(User user);

        public Task<User?> UpdatePassword(User user);

        public Task<User?> UpdatePhone(User user);

        public Task<User?> UpdateRole(User user);

        public Task<User?> UpdateUserProfil(User user);
        
    }
}
