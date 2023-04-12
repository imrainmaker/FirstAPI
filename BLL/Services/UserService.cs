using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.DTO;
using DAL.Models.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Add(UserAddDTO userDTO)
        {
            return await _userRepository.Add(userDTO.ToUser());
        }

        public async Task<bool> Delete(int id)
        {
            User? user = await _userRepository.GetById(id);
            return await _userRepository.Delete(user);
        }

        public async Task<IEnumerable<User?>> GetAll()
        {
            return await _userRepository.GetAll() ;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _userRepository.GetByEmail(email);
        }

        public async Task<User?> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User?> GetByPseudo(string pseudo)
        {
            return await _userRepository.GetByPseudo(pseudo);
        }

        public async Task<bool> Login(UserLoginDTO login)
        {

            User? user = await _userRepository.GetByEmail(login.Email);
            if (user is not null && (user.Password == login.Password))
            {
                return true;
            }
            return false;
        }

        public async Task<User?> UpdatePassword(UserPwdDTO password, int id)
        {
            User? user = await _userRepository.GetById(id);
            if (user is not null && (user.Password == password.Password))
            {
                user.Password =password.NewPassword;
                return await _userRepository.UpdatePassword(user);
            }
            return null;
        }

        public async Task<User?> UpdatePhone(UserPhoneDTO phone, int id)
        {
            User? user = await _userRepository.GetById(id);
            if(user is not null)
            {
                user.Phone = phone.Phone;
                return await _userRepository.UpdatePhone(user);
            }
            return null;
        }

        public async Task<User?> UpdateRole(UserRoleDTO role, int id)
        {
            User? user = await _userRepository.GetById(id);
            if (user is not null && (role.Role == "admin" || role.Role == "user"))
            {
                user.Role = role.Role;
                return await _userRepository.UpdateRole(user);
            }
            return null;
        }

        public async Task<User?> UpdateUserProfil(UserProfilDTO profil, int id)
        {
            User? user = await _userRepository.GetById(id);
            if (user is not null)
            {
                user.Pseudo = profil.Pseudo;
                user.Firstname = profil.Firstname;
                user.Lastname = profil.Lastname;
                return await _userRepository.UpdateUserProfil(user);
            }
            return null;
        }
    }
}
