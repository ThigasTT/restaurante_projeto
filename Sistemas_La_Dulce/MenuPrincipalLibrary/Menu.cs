using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPrincipalLibrary
{
    public class Menu
    {
        public string painel()
        {
            string op;
            Console.WriteLine("RESTAURANTE LA DULCE\n\n");
            Console.WriteLine("Onde você deseja ir?\n");
            Console.WriteLine("Estoque-1\n");
            Console.WriteLine("Financeiro-2\n");
            Console.WriteLine("Fornecedores-3\n");
            Console.WriteLine("Reservas-4\n");
            Console.WriteLine("Recursos Humanos-5\n");
            Console.WriteLine("Sair-q");
            op = Console.ReadLine();

            return op;
        }
        /*public void opcoes()
        {
            
                switch (painel())
                {
                    case "1":
                        Console.WriteLine("Qual o nome do produto?");
                     //   Estoque e = new Estoque(Console.ReadLine());
                        Console.Clear();
                        e.menuestoque();
                        break;
                    case "2":
                        Console.Clear();
                       // Balanco_patrimonial b = new Balanco_patrimonial();
                       // if (//b.exe == false)
                        {

                        }
                        break;
                    case "3":
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        break;
                    case "q":
                        Console.WriteLine("Encerrando");
                        break;
                }
            

        }*/
    }
}
