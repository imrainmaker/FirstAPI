using DAL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
