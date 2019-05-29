using System;

namespace OnlinePlatform
{
    public class Perisabil : Produs
    {
        public  DateTime DataExpirare { get; private set; }

        public Perisabil() : base() { }

        public Perisabil(int Id, string Denumire, string Descriere, string Categorie, double Pret, bool Perisabil, DateTime DataExpirare)
            : base(Id, Denumire, Descriere, Categorie, Pret, Perisabil)
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

        public override void WriteToFile()
        {
            string line = this.Id.ToString() + '|' +
                          this.Denumire + '|' +
                          this.Descriere + '|' +
                          this.Categorie + '|' +
                          this.Pret.ToString() + '|' +
                          this.Perisabil.ToString() + '|' +
                          this.DataExpirare + "\n";
            System.IO.File.AppendAllText("Perisabile.txt", line);
        }
    }
}
