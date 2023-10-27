using AvaliacaoSesab.Models;

namespace AvaliacaoSesab.Repository
{
    public interface IPersonRepository
    {
        List<PersonModel> GetAll();

        PersonModel GetById(int id);
        
        PersonModel GetByCPF(string cpf);
        
        PersonModel GetByData(DateTime? dateStart, DateTime? dateEnd);

        List<PersonModel> GetBySearch(SearchModel search);



    }
}
