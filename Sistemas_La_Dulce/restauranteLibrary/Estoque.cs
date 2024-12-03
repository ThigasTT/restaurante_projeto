using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.AccessControl;
using System.Security.Cryptography;
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

        public void menuestoque(int id)
        {

            this.id = id;
           
            CarregarDadosDoBanco(this.id);
            string op;
            Console.WriteLine("Estoque\n\n");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("Listar produtos - 1");
            Console.WriteLine("Consultar estoque-2");
            Console.WriteLine("Relatar entrada-3");
            Console.WriteLine("Relatar saída-4");
            Console.WriteLine("Sair-q");
            op = Console.ReadLine();
            execução(op);

        }


            public void execução(string opção)
            {
                switch (opção)
                { 
                    case "1":
                    listaProd();
                        break;
                    case "2":
                        exibir();
                        Console.ReadKey();
                        menuestoque(id);
                        break;
                    case "3":
                        Console.WriteLine("Digite a quantidade de itens que entraram e em seguida o custo unitário\n");
                        atSaldo(int.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                        break;
                    case "4":
                        Console.WriteLine("Digite a quantidade de itens que sairão\n");
                        redSaldo(int.Parse(Console.ReadLine()));
                        break;
                   
                    case "q":
                    Thread.Sleep(1000); 
                    break;
                  

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

            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                try
                {
                    connection.Open();


                    string query = "update Produtos SET Saldo = @saldo, Custo = @c_prod, Quantidade = @qtd where idProdutos = @id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@saldo", this.Saldo);
                    cmd.Parameters.AddWithValue("@c_prod", this.c_prod);
                    cmd.Parameters.AddWithValue("@qtd", this.Qtd_prod);
                    cmd.Parameters.AddWithValue("@id", this.id);

                    int linhasAfetadas = cmd.ExecuteNonQuery();


                    if (linhasAfetadas > 0)
                    {
                        Console.WriteLine("Produto atualizado com sucesso.");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma linha foi afetada. Verifique se o idProduto é válido.");
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao acessar o banco de dados: " + ex.Message);
                }
                menuestoque(id);
            }
        }
        public void redSaldo(int qtd)
        {
            this.Saldo = this.Saldo - qtd * this.c_prod;
            this.Qtd_prod = this.Qtd_prod - qtd;
            this.c_prod = this.Saldo / this.Qtd_prod;

            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                try
                {
                    connection.Open();


                    string query = "update Produtos SET Saldo = @saldo, Custo = @c_prod, Quantidade = @qtd where idProdutos = @id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@saldo", this.Saldo);
                    cmd.Parameters.AddWithValue("@c_prod", this.c_prod);
                    cmd.Parameters.AddWithValue("@qtd", this.Qtd_prod);
                    cmd.Parameters.AddWithValue("@id", this.id);

                    int linhasAfetadas = cmd.ExecuteNonQuery();


                    if (linhasAfetadas > 0)
                    {
                        Console.WriteLine("Produto atualizado com sucesso.");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma linha foi afetada. Verifique se o idProduto é válido.");
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao acessar o banco de dados: " + ex.Message);
                }
                menuestoque(id);
            }
        }

      public void CarregarDadosDoBanco(int idProduto)
    {
        
        using (MySqlConnection connection = new MySqlConnection(conexao))
        {
            try
            {
                connection.Open();

               
                string query = "SELECT Nome_P, Quantidade, Custo, Saldo FROM Produtos WHERE idProdutos = @idProduto";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idProduto", id);
                  /*  Console.WriteLine(id);
                    Console.ReadKey();*/
               
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                    
                        this.Nome_prod = reader["Nome_P"].ToString();
                        this.Qtd_prod = Convert.ToInt32(reader["Quantidade"]);
                    //    Validade = Convert.ToDateTime(reader["Validade"]);
                    //    Preco_prod = Convert.ToDouble(reader["Preço"]);
                        this.c_prod = Convert.ToDouble(reader["Custo"]);
                            this.Saldo = Convert.ToDouble(reader["Saldo"]);
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

        public void listaProd()
        {
            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT idProdutos, Nome_P,Quantidade,Custo,Saldo FROM Produtos";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("{0,-10} {1,-15} {2,-20} {3,-25} {4,-15}", "Id", "Nome", "Quantidade", "Custo", "Saldo do estoque");
                        Console.WriteLine(new string('-', 100));

                        while (reader.Read())
                        {
                            Console.WriteLine("{0,-10} {1,-20} {2,-25} {3,-25} {4,-25}",
                                reader["idProdutos"], reader["Nome_P"], reader["Quantidade"], reader["Custo"], reader["Saldo"]);
                            Console.WriteLine(new string('-', 100));
                        }
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine("Erro ao acessar o banco de dados: " + ex.Message);
                }
            }

            using (MySqlConnection connection = new MySqlConnection(conexao))
                try
                {
                    connection.Open();
                    string query = "select sum(saldo) as total from Produtos";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Total no estoque:{0,-10}", reader["total"]);
                            Console.WriteLine(new string('-', 100));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao acessar o banco de dados: " + ex.Message);
                }
            Console.WriteLine("Aperte qualquer tecla para ir ao menu");
            Console.ReadKey();
            Console.WriteLine("\n\nQual o id do produto?");
            int id = int.Parse(Console.ReadLine());
            menuestoque(id);


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
