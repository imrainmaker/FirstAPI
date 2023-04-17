using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.DTO;
using DAL.Models.Mapper;
using DAL.Models.ViewModels;
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
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<UserViewModel?> Add(UserAddDTO userDTO)
        {
            User? user = await _userRepository.Add(userDTO.ToUser());
            return  user?.ToUserViewModel();
        }

        public async Task<bool> Delete(int id)
        {
            User? user = await _userRepository.GetById(id);
            return user is not null ? await _userRepository.Delete(user) : false;
        }

        public async Task<IEnumerable<UserViewModel>?> GetAll()
        {
            IEnumerable<User>? userList = await _userRepository.GetAll();
            if(userList is null)
            {
                return null;
            }
            List<UserViewModel> userVMList = new List<UserViewModel>();
            foreach (User u in userList)
            {
                userVMList.Add(u.ToUserViewModel());
            }
            return userVMList;
        }

        public async Task<UserViewModel?> GetByEmail(string email)
        {
            User? user = await _userRepository.GetByEmail(email);
            return user is not null ? user.ToUserViewModel() : null;
        }

        public async Task<UserViewModel?> GetById(int id)
        {
            User? user = await _userRepository.GetById(id);
            return user is not null ? user.ToUserViewModel() : null;
        }

        public async Task<UserViewModel?> GetByPseudo(string pseudo)
        {
            User? user = await _userRepository.GetByPseudo(pseudo);
            return user is not null ? user.ToUserViewModel() : null;
        }

        public async Task<string?> Login(UserLoginDTO login)
        {

            User? user = await _userRepository.GetByEmail(login.Email);
            if (user is not null && (user.Password == login.Password))
            {
                return _jwtService.GenerateToken(user);
            }
            return null;
        }

        public async Task<UserViewModel?> UpdatePassword(UserPwdDTO password, int id)
        {
            User? user = await _userRepository.GetById(id);
            if (user is not null && (user.Password == password.Password))
            {
                user.Password = password.NewPassword;
                user = await _userRepository.UpdateUser(user);
                return user.ToUserViewModel();
            }
            return null;
        }

        public async Task<UserViewModel?> UpdatePhone(UserPhoneDTO phone, int id)
        {
            User? user = await _userRepository.GetById(id);
            if(user is not null)
            {
                user.Phone = phone.Phone;
                user = await _userRepository.UpdateUser(user);
                return user.ToUserViewModel();
            }
            return null;
        }

        public async Task<UserViewModel?> UpdateRole(UserRoleDTO role, int id)
        {
            User? user = await _userRepository.GetById(id);
            if (user is not null && (role.Role == "admin" || role.Role == "user"))
            {
                user.Role = role.Role;
                user = await _userRepository.UpdateUser(user);
                return user.ToUserViewModel();
            }
            return null;
        }

        public async Task<UserViewModel?> UpdateUserProfil(UserProfilDTO profil, int id)
        {
            User? user = await _userRepository.GetById(id);
            if (user is not null)
            {
                user.Pseudo = profil.Pseudo;
                user.Firstname = profil.Firstname;
                user.Lastname = profil.Lastname;
                user = await _userRepository.UpdateUser(user);
                return user.ToUserViewModel();
            }
            return null;
        }
    }
}
