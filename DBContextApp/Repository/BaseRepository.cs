using DBContextApp.Context;

namespace DBContextApp.Repository
{
    public abstract class BaseRepository
    {
        public abstract Task Create<T>(T model) where T : class;
        
        public abstract Task Delete<T>(int id) where T : class;

        public abstract Task Update<T>(T model) where T : class;

        public abstract Task GetOne<T>(int id) where T : class;
        
        public abstract Task GetAll<T>() where T : class;
    }
}