using DAL.Context;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User?> Add(User user)
        {
            try
            {
                await _context.users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> Delete(User user)
        {
            try
            {
                _context.users.Remove(user);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return  await _context.users.ToListAsync();
        }

        public async Task<User?> GetByEmail(string email)
        {
            try
            {

                return await _context.users.FirstAsync(u => u.Email == email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<User?> GetById(int id)
        {
            try
            {

                return await _context.users.FindAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<User?> GetByPseudo(string pseudo)
        {
            try
            {

                return await _context.users.FirstAsync(u => u.Pseudo == pseudo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<User?> UpdateUser(User user)
        {
            try
            {
                _context.users.Update(user);
                await _context.SaveChangesAsync();
                return user;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
