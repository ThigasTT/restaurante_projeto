using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estoqueLibrary
{
    public class estoque
    {
        public string Nome_prod {  get; set; }
        public int Qtd_prod { get; set; }
        //  public double Prc_prod { get; set; 
        public double Saldo { get; set; }
        public double Pr_Unit { get; set; }
        public void atSaldo(int qtd, double preco)
        {
            this.Saldo = this.Saldo + qtd * preco;
        }
        public void atQtdProd(int qtd)
        {
            this.Qtd_prod = this.Qtd_prod + qtd;
        }
        public void atPrUnit()
        {
            this.Pr_Unit = this.Saldo / this.Qtd_prod;
        }
    }
}
