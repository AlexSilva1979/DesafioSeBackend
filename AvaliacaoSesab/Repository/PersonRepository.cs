using AvaliacaoSesab.Data;
using AvaliacaoSesab.Models;
using AvaliacaoSesab.Repository;
using System;

namespace AvaliacaoSesab.Repository
{
    public class PersonRepository : IPersonRepository
    {                             
        private readonly DataBaseContext _dataBaseContext;
        public PersonRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        
        public List<PersonModel> GetAll()
        {
            return _dataBaseContext.Person.ToList();
        }

        public PersonModel GetById(int id)
        {
            return  _dataBaseContext.Person.FirstOrDefault(x => x.Id == id);
        }


        public List<PersonModel> GetBySearch(SearchModel model)
        {

            IQueryable<PersonModel> query = _dataBaseContext.Person;
            //query = query.AsQueryable().Where(x => x.Name == model.Name);

            if (model == null)
                return query.ToList();
            else { 
                if(model.Name != null)
                    query = query.AsQueryable().Where(x => x.Name == model.Name);
                if (model.Document != null)
                    query = query.AsQueryable().Where(x => x.Document == model.Document);
                if (model.DateStart != null)
                    query = query.AsQueryable().Where(x => x.CreatedDate >= model.DateStart);
                if (model.DateEnd != null)
                    query = query.AsQueryable().Where(x => x.CreatedDate <= model.DateStart);

            }

            return query.ToList();
        }


        public PersonModel GetByCPF(string cpf)
        {
            return null;
        }

        public PersonModel GetByData(DateTime? dateStart, DateTime? dateEnd)
        {
            return null;
        }



    }
}

