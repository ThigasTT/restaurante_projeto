using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace restauranteLibrary
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Tel_C { get; set; }
        public string Email { get; set; }
        public string Data_de_Contratação { get; set; }
        public string conexao;

        public Funcionario(string conexao)
        {
            this.conexao = conexao; 
        }
        public void menuFunc()
        {
            Console.WriteLine("Recursos Humanos \n");
            Console.WriteLine("Consultar dados de um funcionario - 1");
            Console.WriteLine("Cadastrar Funcionário - 2");
            Console.WriteLine("Atualizar dados do funcionario - 3");
            string op = Console.ReadLine();
            escolha(op);

        }
        public void escolha(string opcao)
        {
            switch (opcao)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
        public void carregarDadosDoBanco(string nome) 
        {
            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                try
                {
                    connection.Open();


                    string query = "SELECT Nome, Cargo, Tel_C, Email, Data_de_Contratacao FROM Recursos_Humanos WHERE Nome = @nome";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    /*  Console.WriteLine(id);
                      Console.ReadKey();*/

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            this.Nome = reader["Nome"].ToString();
                            this.Cargo = reader["Cargo"].ToString();
                            this.Tel_C = reader["Tel_C"].ToString();
                            this.Email = reader["Email"].ToString();
                            this.Data_de_Contratação = reader["Data_de_Contratação"].ToString();
                        }
                        else
                        {
                            Console.WriteLine("Funcionario não encontrado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao acessar o banco de dados: " + ex.Message);
                }
            }
        }
    }
}
