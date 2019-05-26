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
