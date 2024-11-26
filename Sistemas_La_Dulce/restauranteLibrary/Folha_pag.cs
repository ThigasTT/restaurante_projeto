using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restauranteLibrary
{
    public class Folha_pag
    {
        public int idFolha { get; set; }
        public int idFunc { get; set; }
        public double Salario { get; set; }
        public int Faltas { get; set; }
        public double Atrasos { get; set; }
        public double Hora_Extra { get; set; }
        public int Jornada_Mês { get; set; }
        public string Data_folha { get; set; }//mês e ano xx/yyyy
        public string conexao;
        public Folha_pag(string conexao)
        {
            this.conexao = conexao;
        }

        public void menuFol()
        {
            string op;
            Console.WriteLine("Folha de pagamento do funcionario");
            Console.WriteLine("\nSe for a primeira vez, crie nova folha de pagamento para o funcionario\n");
            Console.WriteLine("Consultar a folha de pagamento - 1");
            Console.WriteLine("criar nova folha de pagamento - 2");
            Console.WriteLine("atualizar folha de pagamento - 3");

            op = Console.ReadLine();
            escolha(op);
        }

        public void escolha(string opcao)
        {

        }

        public void criaFolha()
        {
            Console.WriteLine("Digite o salario");
            this.Salario = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o numero de faltas");
            this.Faltas = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite as horas de atrasos (em minutos)");
            this.Atrasos = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite quantas horas extras o empregado fez (em minutos)");
            this.Hora_Extra = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite a jornada mensal do funcionario");
            this.Jornada_Mês = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o mês e o ano referente à essa folha ex: mm/aaaa");
            this.Data_folha = Console.ReadLine();

        }

        public void CarregarDadosDoBanco(int idFunc)
        {

            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                try
                {
                    connection.Open();


                    string query = "SELECT * FROM Folha_Pag WHERE idFuncionario = @idFunc";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@idFunc", this.idFunc);
                    /*  Console.WriteLine(id);
                      Console.ReadKey();*/

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.idFolha = Convert.ToInt32(reader["idFolha_Pag"]);
                            this.Salario = Convert.ToDouble(reader["Salario"]);
                            this.Faltas = Convert.ToInt32(reader["Faltas"]);
                            this.Atrasos = Convert.ToDouble(reader["Atrasos"]);
                            this.Hora_Extra = Convert.ToDouble(reader["Hora_Extra"]);
                            this.Jornada_Mês = Convert.ToInt32(reader["Jornada_Mes"]);
                            this.Data_folha = reader["Data_folha"].ToString();
                        }
                        else
                        {
                            Console.WriteLine("Funcionario não encontrado.");
                            Console.WriteLine("\nSe for a primeira vez entrando com esse funcionario, crie nova folha de pagamento para ele\n");
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
