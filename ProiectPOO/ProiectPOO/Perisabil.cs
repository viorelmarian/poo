using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Perisabil : Produs
    {
        private DateTime DataExpirare { get; set; }
        public Perisabil() : base() { }

        public Perisabil(Guid Id, string Denumire, string Descriere, string Categorie, float Pret, DateTime DataExpirare)
            : base(Id, Denumire, Descriere, Categorie, Pret)
        {
            this.DataExpirare = DataExpirare;
        }

        public override bool CheckValability()
        {
            if (DateTime.Compare(DateTime.Now, this.DataExpirare) <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
