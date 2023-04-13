using DAL.Models.DTO;
using DAL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Mapper
{
    public static class UserMapper
    {
        public static User ToUser(this UserAddDTO userAdd)
        {
            return new User(userAdd.Email, userAdd.Password, userAdd.Pseudo,null,null,null);
        }

        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Pseudo = user.Pseudo,
                Lastname = user.Lastname,
                Firstname = user.Firstname,
                Phone = user.Phone,
                Role = user.Role
            };
        }

        public static UserPhoneViewModel ToUserPhoneViewModel(this User user)
        {
            return new UserPhoneViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Pseudo = user.Pseudo,
                Phone = user.Phone,

            };
        }

        public static UserProfilViewModel ToUserProfilViewModel(this User user)
        {
            return new UserProfilViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Pseudo = user.Pseudo,
                Lastname = user.Lastname,
                Firstname = user.Firstname,
            };
        }

        public static UserRoleViewModel ToUserRoleViewModel(this User user)
        {
            return new UserRoleViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Pseudo = user.Pseudo,
                Role = user.Role
            };
        }

    }
}
