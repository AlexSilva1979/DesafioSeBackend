using AvaliacaoSesab.Models;
using System.Net;

namespace AvaliacaoSesab.Repository
{
    public interface IAddressRepository
    {
        
        List<AddressModel> GetAll();
        AddressModel GetById(int id);
        


    }
}
