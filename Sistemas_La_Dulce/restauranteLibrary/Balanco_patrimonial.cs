using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace restauranteLibrary
{
    public class Balanco_patrimonial
    {
        // Propriedades do Balanço Patrimonial
        public double Ativo { get; set; }
        public double Passivo { get; set; }
        public double Capital_social { get; set; }
        public double Caixa { get; set; }
        public double Salário_fun { get; set; }
        public double Estoque { get; set; }
        public double Compras_prazo { get; set; }
        public double Emprestimos { get; set; }
        public double Dre { get; set; }
        public string conexao;

        public Balanco_patrimonial(string conexao)
        {
            this.conexao = conexao;
        }

        // Menu principal de ações financeiras
        public void menuFinanceiro()
        {
            string op;
            CarregarDadosDoBanco();
            Console.WriteLine("Contabilidade do restaurante La Dulce\n\n");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("Consultar o balanço-1");
            Console.WriteLine("Atualizar o balanço-2");
            Console.WriteLine("Voltar-q");
            op = Console.ReadLine();
            opcoes(op);
        }

        // Consultar o balanço
        public void consultar()
        {
            Console.WriteLine("Ativo: " + Ativo);
            Console.WriteLine("Caixa: " + Caixa);
            Console.WriteLine("Estoque: " + Estoque);
            Console.WriteLine("Passivo: " + Passivo);
            Console.WriteLine("Compras a prazo: " + Compras_prazo);
            Console.WriteLine("Empréstimos: " + Emprestimos);
            Console.WriteLine("Lucro: " + Dre);
            Console.WriteLine("Capital social: " + Capital_social);
            Console.ReadKey();
        }

        // Atualizar o balanço
        public void atualizar()
        {
            string op;

            Console.WriteLine("Deseja atualizar tudo? s/n");
            op = Console.ReadLine();
            Console.WriteLine(op);

            if (op == "s")
            {
                calculoDre();
                calculaAtivo();
                calculaPassivo();
                atualizarBanco();
                menuFinanceiro();
            }
            else
            {
                op = atUmaUnidade();
                switch (op)
                {
                    case "1":
                        calculoDre();
                        atualizarBanco();
                        menuFinanceiro();
                        break;
                    case "2":
                        calculaAtivo();
                        atualizarBanco();
                        menuFinanceiro();
                        break;
                    case "3":
                        calculaPassivo();
                        atualizarBanco();
                        menuFinanceiro();
                        break;
                }
            }
        }


        void atualizarBanco()
        {
            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Financeiro SET Ativo = @Ativo, Passivo = @Passivo, Capital_Social = @Capital, DRE = @DRE, Salario_Fun = @Salario_Fun, Caixa = @Caixa, Estoque = @Estoque, Compras_prazo = @Compras_prazo, Emprestimos = @Emprestimos WHERE idFinanceiro = 1";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Ativo", this.Ativo);
                    cmd.Parameters.AddWithValue("@Passivo", this.Passivo);
                    cmd.Parameters.AddWithValue("@Capital", this.Capital_social);
                    cmd.Parameters.AddWithValue("@DRE", this.Dre);
                    cmd.Parameters.AddWithValue("@Salario_Fun", this.Salário_fun);
                    cmd.Parameters.AddWithValue("@Caixa", this.Caixa);
                    cmd.Parameters.AddWithValue("@Estoque", this.Estoque);
                    cmd.Parameters.AddWithValue("@Compras_prazo", this.Compras_prazo);
                    cmd.Parameters.AddWithValue("@Emprestimos", this.Emprestimos);

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        Console.WriteLine("Balanço atualizado com sucesso.");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma linha foi afetada.");
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao acessar o banco de dados: " + ex.Message);
                }
            }
        }


        public string atUmaUnidade()
        {
            Console.WriteLine("O que deseja atualizar?");
            Console.WriteLine("1 - Apuração do DRE");
            Console.WriteLine("2 - Saldo do estoque e caixa");
            Console.WriteLine("3 - Compras a prazo e empréstimos");
            string op = Console.ReadLine();
            return op;
        }

        public void calculoDre()
        {
            double receita, custo;
            Console.WriteLine("Qual foi sua receita no último período?");
            receita = double.Parse(Console.ReadLine());
            Console.WriteLine("Qual foi seu custo total no último período?");
            custo = double.Parse(Console.ReadLine());

            this.Dre = receita - custo;
        }
    public void calculaAtivo()
        {
            Console.WriteLine("Qual o saldo do estoque?");
            this.Estoque = double.Parse(Console.ReadLine());
            Console.WriteLine("Qual o total no caixa?");
            this.Caixa = double.Parse(Console.ReadLine());
            this.Ativo = this.Caixa + this.Estoque;
        }


        public void calculaPassivo()
        {
            Console.WriteLine("Qual o total de compras a prazo?");
            this.Compras_prazo = double.Parse(Console.ReadLine());
            Console.WriteLine("Qual o total de empréstimos?");
            this.Emprestimos = double.Parse(Console.ReadLine());
            this.Passivo = this.Compras_prazo + this.Emprestimos;
        }


        public void verifica()
        {
            if (this.Ativo == this.Passivo)
            {
                Console.WriteLine("O balanço está correto.");
            }
            else
            {
                Console.WriteLine("O balanço está incorreto.");
            }
        }

    
        public void CarregarDadosDoBanco()
        {
            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Ativo, Passivo, Capital_Social, DRE, Salario_Fun, Caixa, Estoque, Compras_prazo, Emprestimos FROM Financeiro WHERE idFinanceiro = 1";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", 1);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.Ativo = Convert.ToDouble(reader["Ativo"]);
                            this.Passivo = Convert.ToDouble(reader["Passivo"]);
                            this.Capital_social = Convert.ToDouble(reader["Capital_Social"]);
                            this.Caixa = Convert.ToDouble(reader["Caixa"]);
                            this.Dre = Convert.ToDouble(reader["Dre"]);
                            this.Estoque = Convert.ToDouble(reader["Estoque"]);
                            this.Compras_prazo = Convert.ToDouble(reader["Compras_prazo"]);
                            this.Emprestimos = Convert.ToDouble(reader["Emprestimos"]);
                        }
                        else
                        {
                            Console.WriteLine("Erro: Balanço não encontrado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao acessar o banco de dados: " + ex.Message);
                }
            }
        }

  
        void opcoes(string op)
        {
            switch (op)
            {
                case "1":
                    consultar();
                    break;
                case "2":
                    atualizar();
                    break;
                case "3":
                    verifica();
                    break;
                case "q":
                    Thread.Sleep(1000);
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

}
