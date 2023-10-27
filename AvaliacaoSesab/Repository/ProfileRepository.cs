using AvaliacaoSesab.Data;
using AvaliacaoSesab.Models;
using AvaliacaoSesab.Repository;
using System;

namespace AvaliacaoSesab.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public ProfileRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
     

        public List<ProfileModel> GetAll()
        {
            return _dataBaseContext.Profile.ToList();
        }

        public ProfileModel GetById(int id)
        {
            return _dataBaseContext.Profile.FirstOrDefault(x => x.Id == id);
        }

       
    }
}

