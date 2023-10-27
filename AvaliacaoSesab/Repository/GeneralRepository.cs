using AvaliacaoSesab.Data;

namespace AvaliacaoSesab.Repository
{
    public class GeneralRepository : IGeneralRepository
    {
        DataBaseContext _dataBaseContext;

        public GeneralRepository(DataBaseContext dataBaseContext )
        {
            _dataBaseContext = dataBaseContext;
            
        }

        public void Add<T>(T entity) where T : class
        {
            _dataBaseContext.Add( entity );
        }

        public void Delete<T>(T entity) where T : class
        {
            _dataBaseContext.Remove( entity );
        }

        public void Update<T>(T entity) where T : class
        {
            _dataBaseContext.Update( entity );
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _dataBaseContext.SaveChangesAsync() > 0);
        }
    }
}
