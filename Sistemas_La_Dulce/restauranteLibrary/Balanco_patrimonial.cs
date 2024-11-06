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
        public void verificacao()
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

            Console.ReadKey();
        }

        public void atualizar()
        {
            string op;

            Console.WriteLine("Deseja atualizar tudo? s/n");
            op = Console.ReadLine();
            Console.WriteLine(op);
            if (op == "s") {
                calculoDre();
                calculaAtivo();
                calculaPassivo();
                menuFinanceiro();
            }
            else
            {
                op=atUmaUnidade();
                switch (op)
                {
                    case "1":
                        calculoDre();
                        break;
                    case "2":
                        calculaAtivo();
                        break;
                    case "3":
                        calculaPassivo();
                        break;
                    
                }
                            
            }
        }
            public string atUmaUnidade()
        {
            Console.WriteLine("O que deseja atualizar?");
            Console.WriteLine("1-apuração do dre");
            Console.WriteLine("2-Saldo do estoque e caixa");
            Console.WriteLine("3-Compras a prazo e estoque");
            Console.WriteLine("4-Verificar o balanço");
            string op = Console.ReadLine();
            return op;
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
        void voltarMenu()
        {
            Console.WriteLine("Voltar ao menu s/n");
            string op = Console.ReadLine();
            if (op=="s")
            {
                menuFinanceiro();
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
                    break;
                case "3":
                    verifica();
                    break;
                case "q":
                    break;
            }
        }
    }

}
