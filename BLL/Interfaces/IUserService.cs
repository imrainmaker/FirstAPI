using DAL.Models;
using DAL.Models.DTO;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAll();

        public Task<User?> GetById(int id);

        public Task<User?> GetByEmail(string email);

        public Task<User?> GetByPseudo(string pseudo);

        public Task<bool> Login(UserLoginDTO login);

        public Task<User?> Add(UserAddDTO user);

        public Task<bool> Delete(int id);

        public Task<User?> UpdatePassword(UserPwdDTO password, int id);

        public Task<User?> UpdatePhone(UserPhoneDTO phone, int id);

        public Task<User?> UpdateRole(UserRoleDTO role, int id);

        public Task<User?> UpdateUserProfil(UserProfilDTO profil, int id);

    }
}
