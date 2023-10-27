using AvaliacaoSesab.Data;
using AvaliacaoSesab.Models;
using AvaliacaoSesab.Repository;
using System;

namespace AvaliacaoSesab.Repository
{
    public class StatRepository : IStatRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public StatRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
     

        public StatModel GetAll()
        {
            var users = _dataBaseContext.User.ToList();
            var persons = _dataBaseContext.Person.ToList();

            var stats = new StatModel();

            stats.Users = users.Count();
            stats.Persons = persons.Count();

            return stats;
        }

    }
}

