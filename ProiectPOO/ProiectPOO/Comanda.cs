using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comanda
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public List<Tuple<Guid, int>> Produse { get; private set; }

        public Comanda(Guid ClientId)
        {
            this.ClientId = ClientId;
            this.Id = Guid.NewGuid();
            this.Produse = new List<Tuple<Guid, int>>();
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