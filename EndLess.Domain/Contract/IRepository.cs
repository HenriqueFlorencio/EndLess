using EndLess.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EndLess.Domain.Contract
{
    public interface IRepository<T>: IDisposable where T:Entity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> Get();
        T Get(object id);
    }
}
