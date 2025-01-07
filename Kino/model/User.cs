using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.model
{
    public class User
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PasswordHash { get; set; }
        public int Role { get; set; }

        public User(int idUser, string username, string name, string surname, string passwordHash, int role)
        {
            IdUser = idUser;
            Username = username;
            Name = name;
            Surname = surname;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}
