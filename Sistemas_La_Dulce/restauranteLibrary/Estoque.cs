using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace restauranteLibrary
{
    public class Estoque
    {
        public Estoque()
        {
            Nome_prod = null;
            Qtd_prod = 0;
            Saldo = 0;
            c_prod = 0;
        }
        public Estoque(string nome_prod)        {
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
            Console.WriteLine("Sair-q");
            op = Console.ReadLine();
            execução(op);

        }


            public void execução(string opção)
            {
                switch (opção)
                {
                    case "1":
                        exibir();
                        Console.ReadKey();
                        menuestoque();
                        break;
                    case "2":
                        Console.WriteLine("Digite a quantidade de itens que entraram e em seguida o custo unitário\n");
                        atSaldo(int.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                        break;
                    case "3":
                        Console.WriteLine("Digite a quantidade de itens que sairão\n");
                        redSaldo(int.Parse(Console.ReadLine()));
                        break;
                    case "4":
                    Console.WriteLine("Qual o nome do produto?");
                    string nome = Console.ReadLine();
                    Estoque e = new Estoque(nome);
                    break;
                    case "q":
                    Console.ReadKey();
                    return;
                  

                }
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
