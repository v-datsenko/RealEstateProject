using ApplicationCore.Models.Characters;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Text;

namespace ApplicationCore.Services
{
    public class RealEstateDataContext : DataContext
    {
        public Table<User> Users;
        public RealEstateDataContext(string connection) : base(connection) { }
    }
}
