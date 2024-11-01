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
        /*public string opcoes(string op)
        {

        }*/
    }
}
