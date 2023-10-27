
using AvaliacaoSesab.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoSesab.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) :base(options) { }

        public DbSet<AddressModel> Address { get; set; }
        public DbSet<PersonModel> Person { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<ProfileModel> Profile { get; set; }
        

    }
}
