using AvaliacaoSesab.Models;

namespace AvaliacaoSesab.Repository
{
    public interface IProfileRepository
    {
        
        List<ProfileModel> GetAll();
        ProfileModel GetById(int id);
       


    }
}
