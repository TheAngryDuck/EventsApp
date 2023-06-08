namespace EventAppDataLayer.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        T Add(T entity);
        void Remove(Guid id);
    }
}
