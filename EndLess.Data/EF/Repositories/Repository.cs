using EndLess.Domain.Contract;
using EndLess.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EndLess.Data.EF.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly EndLessDataContext _ctx = new EndLessDataContext();

        public void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            save();
        }

        private void save()
        {
            _ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            save();
        }

        public IEnumerable<T> Get()
        {
            return _ctx.Set<T>().ToList();
        }

        public T Get(object id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            save();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
