using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        private Guid Id { get; set; }
        private string Nume { get; set; }
        private string Prenume { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Email { get; set; }

        public User()
        {
            this.Id = Guid.NewGuid();
        }

        public User(Guid Id, string Nume, string Prenume, string Username, string Password, string Email)
        {
            this.Id = Id;
            this.Nume = Nume;
            this.Prenume = Prenume;
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
        }

        public void Login()
        {

        }

        public void Register()
        {

        }

        public void WriteToFile()
        {

        }
    }
}
