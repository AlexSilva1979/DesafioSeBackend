using AvaliacaoSesab.Models;

namespace AvaliacaoSesab.Helper
{
    public interface ISessionUser
    {
        void CreateSessionUser(UserModel userModel);

        void RemoveSessionUser();

        UserModel GetSessionUser();

    }
}
