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

        public Task<string?> Login(UserLoginDTO login);

        public Task<UserViewModel?> Add(UserAddDTO user);

        public Task<bool> Delete(int id);

        public Task<UserViewModel?> UpdatePassword(UserPwdDTO password, int id);

        public Task<UserViewModel?> UpdatePhone(UserPhoneDTO phone, int id);

        public Task<UserViewModel?> UpdateRole(UserRoleDTO role, int id);

        public Task<UserViewModel?> UpdateUserProfil(UserProfilDTO profil, int id);

    }
}
