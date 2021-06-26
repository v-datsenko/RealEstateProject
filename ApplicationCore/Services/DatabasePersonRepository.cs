using ApplicationCore.Models.Characters;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace ApplicationCore.Services
{
    public class DatabasePersonRepository : IRepository<Person>
    {
        private RealEstateDataContext _db;
        private string _connectionString;
        private bool disposedValue;

        public DatabasePersonRepository(string connectionString)
        {
            _connectionString = connectionString;
            _db = new RealEstateDataContext(_connectionString);

            if (_db.DatabaseExists())
            {
                _db.DeleteDatabase();
            }
            Console.WriteLine("Создание базы данных...");
            _db.CreateDatabase();
        }

        public void Create(Person item)
        {
            if (item == null)
                return;
            _db.GetTable<User>().InsertOnSubmit(item);
        }

        public void Delete(int id)
        {
            var person = _db.GetTable<User>().Where(u => u.Id == id && u.DiscKey == "Person").FirstOrDefault();
            if(person == null)
                throw new ArgumentOutOfRangeException();
            _db.GetTable<User>().DeleteOnSubmit(person);
        }

        public IEnumerable<Person> GetPeopleList()
        {
            return _db.GetTable<User>().Where(u => u.DiscKey == "Person").Select(u => u as Person).ToList();
        }

        public Person GetPerson(int id)
        {
            var person = _db.GetTable<User>().Where(u => u.Id == id && u.DiscKey == "Person").Select(u => u as Person).FirstOrDefault();
            if (person == null)
                throw new ArgumentOutOfRangeException();
            return person;
        }

        public void Save()
        {
            _db.SubmitChanges();
        }

        public void Update(Person item)
        {
            if (item == null)
                return;
            var currentPerson = _db.GetTable<User>().Where(u => u.Id == item.Id && u.DiscKey == "Person").Select(u => u as Person).FirstOrDefault();
            if(currentPerson == null)
                throw new ArgumentOutOfRangeException();
            currentPerson.Login = item.Login;
            currentPerson.Password = item.Password;
            currentPerson.FirstName = item.FirstName;
            currentPerson.SecondName = item.SecondName;
            currentPerson.Email = item.Email;
            currentPerson.Age = item.Age;
            currentPerson.CreatingDate = item.CreatingDate;
        }
        public void ClearTable()
        {
            var peopleList = _db.GetTable<User>().Where(u => u.DiscKey == "Person").ToList();
            for(int i = 0; i < peopleList.Count; i++)
            {
                Delete(peopleList[i].Id);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                   
                }
                disposedValue = true;

                _db.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
