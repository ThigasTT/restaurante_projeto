using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace restauranteLibrary
{
    public class Estoque
    {
        public Estoque(string conn)
        {

            this.Nome_prod = null;
            this.Qtd_prod = 0;
            this.Saldo = 0;
            this.c_prod = 0;
            this.conexao = conn;
        }
        /*public Estoque(string nome_prod)        {
            this.Nome_prod = nome_prod;
           
        }*/


        public string Nome_prod { get; set; }
        public int Qtd_prod { get; set; }
        //  public double Prc_prod { get; set; 
        public double Saldo { get; set; }
        public double c_prod { get; set; }//custo unitário
        public string conexao;
        public int id;
        //métodos

        public void menuestoque()
        {
            Console.WriteLine("Qual o id do produto?");
            CarregarDadosDoBanco(int.Parse(Console.ReadLine()));
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
                    Thread.Sleep(1000); 
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

      public void CarregarDadosDoBanco(int idProduto)
    {
        
        using (MySqlConnection connection = new MySqlConnection(conexao))
        {
            try
            {
                connection.Open(); // Abre a conexão com o banco de dados

                // Consulta SQL para buscar os dados do produto
                string query = "SELECT Nome_P, Quantidade, Custo FROM Produtos WHERE idProdutos = @idProduto";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idProduto", id);
          
               
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                    
                        this.Nome_prod = reader["Nome_P"].ToString();
                        this.Qtd_prod = Convert.ToInt32(reader["Quantidade"]);
                    //    Validade = Convert.ToDateTime(reader["Validade"]);
                    //    Preco_prod = Convert.ToDouble(reader["Preço"]);
                        this.c_prod = Convert.ToDouble(reader["Custo"]);
                    }
                    else
                    {
                        Console.WriteLine("Produto não encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao acessar o banco de dados: " + ex.Message);
            }
        }
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
