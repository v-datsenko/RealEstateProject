using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetPeopleList();
        T GetPerson(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
