using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Nume { get; private set; }
        public string Prenume { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

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

        public virtual void WriteToFile() { }
    }
}
