using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoreLibrary.Models
{
    public class User : IData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {
           
        }
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"{Id}  {Name} {Email} {Password}";
        }

        public object Clone() => new User(Id, Email, Name, Password);
    }
}
