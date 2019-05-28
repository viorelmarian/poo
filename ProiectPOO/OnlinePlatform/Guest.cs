using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Guest : User
    {
        public Guest() : base() { }
        public Guest(int Id, string Nume, string Prenume, string Username, string Password, string Email, bool IsAdmin) 
            : base(Id, Nume, Prenume, Username, Password, Email, IsAdmin) { }

        public override void WriteToFile()
        {
            string line = this.Id.ToString() + '|' +
                          this.Nume + '|' +
                          this.Prenume + '|' +
                          this.Username + '|' +
                          this.Password + '|' +
                          this.Email + '|' + 
                          this.IsAdmin.ToString() + "\n";
            System.IO.File.AppendAllText("Utilizatori.txt", line);
        }
    }
}
