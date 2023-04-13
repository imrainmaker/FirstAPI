using DAL.Models;
using DAL.Models.DTO;
using DAL.Models.ViewModels;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<UserViewModel?>> GetAll();

        public Task<UserViewModel?> GetById(int id);

        public Task<UserViewModel?> GetByEmail(string email);

        public Task<UserViewModel?> GetByPseudo(string pseudo);

        public Task<bool> Login(UserLoginDTO login);

        public Task<UserViewModel?> Add(UserAddDTO user);

        public Task<bool> Delete(int id);

        public Task<UserViewModel?> UpdatePassword(UserPwdDTO password, int id);

        public Task<UserPhoneViewModel?> UpdatePhone(UserPhoneDTO phone, int id);

        public Task<UserRoleViewModel?> UpdateRole(UserRoleDTO role, int id);

        public Task<UserProfilViewModel?> UpdateUserProfil(UserProfilDTO profil, int id);

    }
}
