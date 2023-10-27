using AvaliacaoSesab.Data;
using AvaliacaoSesab.Models;
using AvaliacaoSesab.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace AvaliacaoSesab.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public UserRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
     

        public List<UserModel> GetAll()
        {
            IQueryable<UserModel> query = _dataBaseContext.User;

            query.Include(a => a.Profile).AsNoTracking();

            return query.ToList();
            //return _dataBaseContext.User.ToList();
        }

        public UserModel GetById(int id)
        {
            return _dataBaseContext.User.FirstOrDefault(x => x.Id == id);
        }

        public UserModel GetByEmail(string email)
        {       
            return _dataBaseContext.User.FirstOrDefault(x => x.Email == email);
        }
        
        public UserModel GetByEmailPassWord(string email, string password)
        {       
            return _dataBaseContext.User.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
      


    }
}

