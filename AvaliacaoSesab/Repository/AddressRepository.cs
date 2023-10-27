using AvaliacaoSesab.Data;
using AvaliacaoSesab.Models;
using AvaliacaoSesab.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace AvaliacaoSesab.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public AddressRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
     

        public List<AddressModel> GetAll()
        {
           return _dataBaseContext.Address.ToList();
        }

        public AddressModel GetById(int id)
        {
            return _dataBaseContext.Address.FirstOrDefault(x => x.Id == id);
        }

    }
}

