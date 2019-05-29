using System;
using System.Collections.Generic;

namespace OnlinePlatform
{
    public class Comanda
    {
        public Int64 Id { get; private set; }
        public int ClientId { get; private set; }
        public List<Tuple<int, int, bool>> Produse { get; private set; }

        public Comanda(int ClientId)
        {
            this.Id = Convert.ToInt64(DateTime.Now.Year.ToString() +
                DateTime.Now.Month.ToString() +
                DateTime.Now.Day.ToString() +
                DateTime.Now.Hour.ToString() +
                DateTime.Now.Minute.ToString() +
                DateTime.Now.Second.ToString() +
                DateTime.Now.Millisecond.ToString());
            this.ClientId = ClientId;
            this.Produse = new List<Tuple<int, int, bool>>();
        }

        public void TrimiteComanda()
        {
            List<string> comanda = new List<string>();

            System.IO.File.AppendAllText("Comanda " + this.Id.ToString() + ".txt", this.ClientId.ToString() + "\n");
            foreach (var item in this.Produse)
            {
                string line = item.Item1.ToString() + '/' + item.Item2;
                comanda.Add(line);
            }
            System.IO.File.AppendAllLines("Comanda " + this.Id.ToString() + ".txt", comanda);
        }
    }
}