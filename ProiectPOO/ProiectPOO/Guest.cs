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
        public Guest(Guid Id, string Nume, string Prenume, string Username, string Password, string Email) 
            : base(Id, Nume, Prenume, Username, Password, Email) { }
    }
}
