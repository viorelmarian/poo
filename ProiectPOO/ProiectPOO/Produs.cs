using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Produs
    {
        private Guid Id { get; set; }
        private string Denumire { get; set; }
        private string Descriere { get; set; }
        private string Categorie { get; set; }
        private float Pret { get; set; }

        public Produs(Guid Id, string Denumire, string Descriere, string Categorie, float Pret)
        {
            this.Id = Id;
            this.Denumire = Denumire;
            this.Descriere = Descriere;
            this.Categorie = Categorie;
            this.Pret = Pret;
        }

        public Produs()
        {
            this.Id = Guid.NewGuid();
        }

        public virtual bool CheckValability()
        {
            return true;
        }
    }
}
