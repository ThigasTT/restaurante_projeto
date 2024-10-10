using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace calculoDRE
{
    internal class Balanço_patrimonial
    {
        public double Ativo { get; set; }

        public double Passivo { get; set; }
        public double Capital_social { get; set; }
        public double Caixa {  get; set; }
        public double Imóvel { get; set; }
        
        public double Estoque { get; set; }
        public double Fornecedores { get; set; }

        public double Emprestimos { get; set; }

        public void calculaAtivo(double caixa, double estoque)
        {
             this.Ativo = caixa + estoque; 
        }
        public void calculaPassivo(double fornecedores, double lucro) 
        {
            this.Passivo = fornecedores + lucro; 
        }
    }
}

