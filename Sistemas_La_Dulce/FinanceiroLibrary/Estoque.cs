using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceiroLibrary;

namespace estoqueLibrary
{
    public class Estoque:Balanco_patrimonial
    {
        public Estoque(string nome_prod)
        {
            this.Nome_prod = nome_prod;
        }
        public string Nome_prod { get; set; }
        public int Qtd_prod { get; set; }
        //  public double Prc_prod { get; set; 
        public double Saldo { get; set; }
        public double c_prod { get; set; }//custo unitário


        //métodos

        public void menuestoque()
        {
            string op;
            Console.WriteLine("Estoque\n\n");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("Consultar estoque-1");
            Console.WriteLine("Relatar entrada-2");
            Console.WriteLine("Relatar saída-3");
            Console.WriteLine("Voltar-q");
            op = Console.ReadLine();
            execução(op);
        }

        
        public void execução(string opção)
        {
            switch (opção)
            {
                case "1":
                    exibir();
                    break;
                case "2":
                    Console.WriteLine("Digite a quantidade de itens que entraram e em seguida o custo unitário\n");
                    atSaldo(int.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())); ;
                    break;
                case "3":
                    Console.WriteLine("Digite a quantidade de itens que sairão\n");
                    redSaldo(int.Parse(Console.ReadLine()));
                    break;
                case "q":
                    Console.Clear();
                    break;
            }
            menuestoque();
        }

        public void exibir()
        {
            Console.WriteLine("Nome do produto: {0}\n", this.Nome_prod);
            Console.WriteLine("Quantidade de produtos: {0}\n", this.Qtd_prod);
            Console.WriteLine("Custo unitário: {0}\n", this.c_prod);
            Console.WriteLine("Saldo do estoque: {0}\n", this.Saldo);
        }
        public void atSaldo(int qtd, double preco)
        {
            this.Saldo = this.Saldo + qtd * preco;
            this.Qtd_prod = this.Qtd_prod + qtd;
            this.c_prod = this.Saldo / this.Qtd_prod;
        }
        public void redSaldo(int qtd)
        {
            this.Saldo = this.Saldo - qtd * this.c_prod;
            this.Qtd_prod = this.Qtd_prod - qtd;
            this.c_prod = this.Saldo / this.Qtd_prod;
        }
        /* public void atQtdProd(int qtd)
         {
             this.Qtd_prod = this.Qtd_prod + qtd;
         }
         public void atPrUnit()
         {
             this.Pr_Unit = this.Saldo / this.Qtd_prod;
         }*/
    }
}
