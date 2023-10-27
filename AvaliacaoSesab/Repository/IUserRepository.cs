using AvaliacaoSesab.Models;

namespace AvaliacaoSesab.Repository
{
    public interface IUserRepository
    {
        
        List<UserModel> GetAll();
        UserModel GetById(int id);
        UserModel GetByEmail(string email);
        UserModel GetByEmailPassWord(string email, string password);


    }
}
