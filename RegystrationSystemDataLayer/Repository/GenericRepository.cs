using EventAppDataLayer.Interface;

namespace EventAppDataLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly EventsAppContext _context;
        public GenericRepository(EventsAppContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
          var result =  _context.Set<T>().Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(Guid id)
        {
           var ob =  _context.Set<T>().Find(id);
            _context.Set<T>().Remove(ob);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
