using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restauranteLibrary
{
    public class Menu
    {

        public string painel()
        {
            string op;
            Console.Clear();
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
        public void opcoes()
        {   
             string  op=painel();
            
                switch (op)
                {
                    case "1":
                        Console.WriteLine("Qual o nome do produto?");
                      
                    Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        
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
            

        }
    }
}
