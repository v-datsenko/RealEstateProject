using System.Data.Linq.Mapping;

namespace ApplicationCore.Models.Characters
{
    [Table(Name = "Users")]
    [InheritanceMapping(Code = "Person", Type = typeof(Person),IsDefault = true)]
    [InheritanceMapping(Code = "Admin", Type = typeof(Admin))]
    public abstract class User
    {
        
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(IsDiscriminator = true, DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string DiscKey { get; set; }
        [Column(DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Login { get; set; }
        [Column(DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Password { get; set; }

        public User() { }
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}