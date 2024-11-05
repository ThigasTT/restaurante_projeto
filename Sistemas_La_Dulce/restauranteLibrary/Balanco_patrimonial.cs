using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restauranteLibrary
{
    public class Balanco_patrimonial
    {
        public double Ativo { get; set; }

        public double Passivo { get; set; }
        public double Capital_social { get; set; }
        public double Caixa { get; set; }

        public double Estoque { get; set; }
        public double Compras_prazo { get; set; }
        public double Emprestimos { get; set; }
        public double Dre { get; set; }
        public bool exe = true;
        public Balanco_patrimonial()
        {
            string conf;
            Console.WriteLine("Já é cadastrado? s/n");
            conf = Console.ReadLine();
            if (conf == "s")
            {
                menuFinanceiro();
            }
            else
            {
                cadastroInf();
                menuFinanceiro();
            }
        }
        public void cadastroInf()
        {
            Console.WriteLine("Qual o valor do Capital social?");
            this.Capital_social = double.Parse(Console.ReadLine());
            Console.WriteLine("Qual o valor do Caixa?");
            this.Caixa = double.Parse(Console.ReadLine());
            Console.WriteLine("Qual o valor das compras a prazo?");
            this.Compras_prazo = double.Parse(Console.ReadLine());
            Console.WriteLine("Qual o valor dos empréstimos?");
            this.Emprestimos = double.Parse(Console.ReadLine());
        }
        public void menuFinanceiro()
        {
            string op;
            Console.WriteLine("Contabilidade do restaurante La Dulce\n\n");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("Consultar o balanço-1");
            Console.WriteLine("Atualizar o balanço-2");
            Console.WriteLine("Voltar-q");
            op = Console.ReadLine();
            opcoes(op);
        }
        public void consultar()
        {

            Console.WriteLine("Ativo:" + Ativo);
            Console.WriteLine("Caixa:" + Caixa);
            Console.WriteLine("Estoque:" + Estoque);
            Console.WriteLine("Passivo:" + Passivo);
            Console.WriteLine("Compras a prazo:" + Compras_prazo);
            Console.WriteLine("Emprestimos:" + Emprestimos);
            Console.WriteLine("Lucro:" + Dre);
            Console.WriteLine("Capital social:" + Capital_social);
        }

        public void atualizar()
        {
            calculoDre();
            calculaAtivo();
            calculaPassivo();
            menuFinanceiro();
        }
        public void calculoDre()
        {
            double receita, custo;
            Console.WriteLine("Qual foi sua receita no ulimo período?");
            receita = double.Parse(Console.ReadLine());
            Console.WriteLine("Qual foi seu custo total no último período?");
            custo = double.Parse(Console.ReadLine());

            this.Dre = receita - custo;
        }
        public void calculaAtivo()
        {
            Console.WriteLine("Qual o saldo do estoque?");
            this.Estoque = double.Parse(Console.ReadLine());
            Console.WriteLine("Qual o total no caixa?");
            this.Caixa = double.Parse(Console.ReadLine());
            this.Ativo = this.Caixa + this.Estoque;
        }
        public void calculaPassivo()
        {
            Console.WriteLine("Qual o total de compras a prazo?");
            this.Compras_prazo = double.Parse(Console.ReadLine());
            Console.WriteLine("Qual o total de empréstimos?");
            this.Emprestimos = double.Parse(Console.ReadLine());
            this.Passivo = this.Compras_prazo + this.Emprestimos;
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

        void opcoes(string op)
        {
            switch (op)
            {
                case "1":
                    consultar();
                    break;

                case "2":
                    atualizar();
                    verifica();
                    break;
                case "q":

                    break;
            }
            Console.Clear();
            Console.WriteLine("voltar para o menu? s/n");
            string o = Console.ReadLine();

            if (o == "s")
            {
                Console.Clear();
                menuFinanceiro();
            }
            else { exe = false; }

            menuFinanceiro();
        }
    }

}
