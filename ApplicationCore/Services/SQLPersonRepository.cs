using ApplicationCore.Models.Characters;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ApplicationCore.Services
{
    public class SQLPersonRepository : IRepository<Person>
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        string sql = "SELECT * FROM Users";
        DataSet ds;

        public SQLPersonRepository(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            adapter = new SqlDataAdapter(sql, connection);
            ds = new DataSet();
            adapter.Fill(ds);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
        }

        public IEnumerable<Person> GetPeopleList()
        {
            List<Person> peopleList = new List<Person>();
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                peopleList.Add(new Person(Convert.ToInt32(row["Id"]), (string)row["Login"], (string)row["Password"], (string)row["FirstName"], (string)row["SecondName"], (string)row["Email"], Convert.ToInt32(row["Age"]), DateTime.Now));
            }
            return peopleList;
        }

        public Person GetPerson(int id)
        {
            DataTable dt = ds.Tables[0];
            DataRow currentRow = null;
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["Id"]) == id)
                    currentRow = row;
            }
            if (currentRow != null)
            {
                return new Person(Convert.ToInt32(currentRow["Id"]), (string)currentRow["Login"], (string)currentRow["Password"], (string)currentRow["FirstName"], (string)currentRow["SecondName"], (string)currentRow["Email"], Convert.ToInt32(currentRow["Age"]), (DateTime)currentRow["CreatingDate"]);

            }
            return null;
        }

        public void Create(Person person)
        {
            DataTable dt = ds.Tables[0];
            DataRow newRow = dt.NewRow();
            newRow["Login"] = person.Login; ;
            newRow["Password"] = person.Password;
            newRow["FirstName"] = person.FirstName;
            newRow["SecondName"] = person.SecondName;
            newRow["Email"] = person.Email;
            newRow["Age"] = person.Age;
            newRow["CreatingDate"] = person.CreatingDate;
            dt.Rows.Add(newRow);

        }

        public void Update(Person person)
        {
            DataTable dt = ds.Tables[0];
            DataRow currentRow = null;
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["Id"]) == person.Id)
                    currentRow = row;
            }
            if (currentRow != null)
            {
                currentRow["Login"] = person.Login; ;
                currentRow["Password"] = person.Password;
                currentRow["FirstName"] = person.FirstName;
                currentRow["SecondName"] = person.SecondName;
                currentRow["Email"] = person.Email;
                currentRow["Age"] = person.Age;
                currentRow["CreatingDate"] = person.CreatingDate;
            }
        }

        public void Delete(int id)
        {
            DataTable dt = ds.Tables[0];
            DataRow currentRow = null;
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["Id"]) == id)
                    currentRow = row;
            }
            if(currentRow != null)
                dt.Rows.Remove(currentRow);

        }

        public void Save()
        {
            adapter.Update(ds);
            ds.AcceptChanges();
            adapter.Fill(ds);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    connection.Close();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
