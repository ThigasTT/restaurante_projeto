using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculoDRE
{
    public class DRE
    {
        public DRE()
        {
        }

        public double Receita { get; set; }
        public double Custo { get; set; }
        public double Dre { get; set; }

        public void dre(double receita, double custo)
        {
            this.Dre = receita - custo;

        }
    }
}
