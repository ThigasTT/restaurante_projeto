using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using estoqueLibrary;
using FinanceiroLibrary;
using fornecedoresLibrary;
using reservasLibrary;
using rhLibrary;
using MenuPrincipalLibrary;



namespace Sistemas_La_Dulce
{
    internal class Program
    {
        static void Main(string[] args)
        {
           /* MySqlCommand cmd;
            MySqlConnection conexao;
            conexao = new MySqlConnection();
            try
            {
                string stringconexao = "server=127.0.0.1;uid=root;pwd='';database=restaurante";
                conexao.ConnectionString = stringconexao;
                conexao.Open();
                Console.WriteLine("Conexão estabelecida");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro gerado" + ex.Message);
                Console.WriteLine("Erro! entre em contato com o administrador");
                Console.ReadKey();
            }
            string sql = "";
            cmd = new MySqlCommand(sql, conexao);*/
            
            /*string op;
            Console.WriteLine("RESTAURANTE LA DULCE\n\n");
            Console.WriteLine("Onde você deseja ir?\n");
            Console.WriteLine("Estoque-1\n");
            Console.WriteLine("Financeiro-2\n");
            Console.WriteLine("Fornecedores-3\n");
            Console.WriteLine("Reservas-4\n");
            Console.WriteLine("Recursos Humanos-5\n");
            Console.WriteLine("Sair-q");
            op =Console.ReadLine();*/
            Menu m = new Menu();
            switch (m.painel())
            {
                case "1":
                    Console.WriteLine("Qual o nome do produto?");
                    Estoque e = new Estoque(Console.ReadLine());
                    Console.Clear();
                    e.menuestoque();
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
           
            Console.ReadKey();
        }
    }
}
