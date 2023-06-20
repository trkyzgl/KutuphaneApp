using DataAccsessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccsessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class, new() 
    {
        private readonly Context _dbContext;
        private readonly DbSet<T> _object;

        public GenericRepository(Context c)
        {
            _dbContext = c;
            _object = c.Set<T>();
        }

        public void Delete(T p)
        {
            _object.Remove(p);
            _dbContext.SaveChanges();
        }

        public void Insert(T p)
        {
            _object.Add(p);
            _dbContext.SaveChanges();
        }

        public List<T> List()
        {
            //List<T> list = _object.ToList();
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }
        public void Update(T p)
        {
            _dbContext.SaveChanges();
        }
    }

}
