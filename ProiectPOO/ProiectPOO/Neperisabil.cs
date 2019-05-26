using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Neperisabil : Produs
    {
        private DateTime DataAchizitie { get; set; }
        private int Garantie { get; set; }

        public Neperisabil() : base() { }

        public Neperisabil(Guid Id, string Denumire, string Descriere, string Categorie, double Pret, DateTime DataAchizitie, int Garantie)
            : base(Id, Denumire, Descriere, Categorie, Pret)
        {
            this.DataAchizitie = DataAchizitie;
            this.Garantie = Garantie;
        }

        public override bool CheckValability()
        {
            if (DateTime.Compare(DateTime.Now, DateTime.Now.AddMonths(this.Garantie)) <= 0)
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
