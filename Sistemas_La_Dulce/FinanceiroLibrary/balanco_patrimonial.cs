using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroLibrary
{
    public class balanco_patrimonial
    {
        public double Ativo { get; set; }

        public double Passivo { get; set; }
        public double Capital_social { get; set; }
        public double Caixa { get; set; }

        public double Estoque { get; set; }
        public double Fornecedores { get; set; }
        public double Emprestimos { get; set; }
        public double Dre { get; set; }


        public void cadastroInf()
        {
            Console.WriteLine("Qual o valor do Capital social?");
            this.Capital_social = double.Parse(Console.ReadLine());
            Console.WriteLine("Qual o valor do Caixa?");
            this.Caixa = double.Parse(Console.ReadLine());
            Console.WriteLine("Qual o valor das compras a prazo?");
            this.Fornecedores = double.Parse(Console.ReadLine());
            Console.WriteLine("Qual o valor dos empréstimos?");
            this.Emprestimos = double.Parse(Console.ReadLine());
        }
        public void calculoDre(double receita, double custo)
        {
            this.Dre = receita - custo;

        }
        public void calculaAtivo()
        {
            this.Ativo = this.Caixa + this.Estoque;
        }
        public void calculaPassivo()
        {
            this.Passivo = this.Fornecedores + this.Emprestimos;
        }
        public void verifica()
        {
            if (this.Ativo - this.Passivo == 0)
            {
                Console.WriteLine("O balanço está correto");
            }
            else
            {
                Console.WriteLine("O balanço está errado");
            }
        }
    }
}
