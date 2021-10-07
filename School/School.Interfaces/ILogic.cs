using System;
using System.Collections.Generic;

namespace School.Interfaces
{
    public interface ILogic<T>
    {
        T Add(T entity);

        bool Remove(int id);

        T Update(T entity);

        T Get(int id);

        IEnumerable<T> GetAll();
    }

}