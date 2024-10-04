using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculoDRE
{
    public class DRE
    {
        public double Receita { get; set; }
        public double Custo { get; set; }
        public double Dre { get; set; }

        public double dre(double receita, double custo)
        {
            this.Dre = receita - custo;

            return Dre;
        }
    }
}
