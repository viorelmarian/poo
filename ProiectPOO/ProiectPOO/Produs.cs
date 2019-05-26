using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Produs
    {
        public Guid Id { get; private set; }
        public string Denumire { get; private set; }
        public string Descriere { get; private set; }
        public string Categorie { get; private set; }
        public double Pret { get; private set; }
        public bool Perisabil { get; private set; }

        public Produs(Guid Id, string Denumire, string Descriere, string Categorie, double Pret, bool Perisabil)
        {
            this.Id = Id;
            this.Denumire = Denumire;
            this.Descriere = Descriere;
            this.Categorie = Categorie;
            this.Pret = Pret;
            this.Perisabil = Perisabil;
        }

        public Produs()
        {
            this.Id = Guid.NewGuid();
        }

        public virtual bool CheckValability()
        {
            return true;
        }

        public virtual void WriteToFile() { }
    }
}
