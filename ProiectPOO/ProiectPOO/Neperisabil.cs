﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Neperisabil : Produs
    {
        public DateTime DataAchizitie { get; private set; }
        public int Garantie { get; private set; }

        public Neperisabil() : base() { }

        public Neperisabil(Guid Id, string Denumire, string Descriere, string Categorie, double Pret, bool Perisabil, DateTime DataAchizitie, int Garantie)
            : base(Id, Denumire, Descriere, Categorie, Pret, Perisabil)
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

        public override void WriteToFile()
        {
            string line = this.Id.ToString() + '|' +
                          this.Denumire + '|' +
                          this.Descriere + '|' +
                          this.Categorie + '|' +
                          this.Pret.ToString() + '|' +
                          this.Perisabil.ToString() + '|' +
                          this.DataAchizitie + '|' +
                          this.Garantie + "\n";
            System.IO.File.WriteAllText("Neperisabile.txt", line);
        }
    }
}
