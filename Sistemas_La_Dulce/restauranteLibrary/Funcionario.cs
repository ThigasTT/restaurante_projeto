using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace restauranteLibrary
{
    public class Funcionario
    {
        public int IdFunc { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Tel_C { get; set; }
        public string Email { get; set; }
        public string Data_de_Contratacao { get; set; }
        public string conexao;
        public Folha_pag fol;
        public Funcionario(string conexao)
        {
            this.conexao = conexao;
             this.fol = new Folha_pag(conexao);
        }
        public void menuFunc()
        {
            Console.Clear();
            Console.WriteLine("Recursos Humanos \n");
            Console.WriteLine("Consultar dados de um funcionario - 1");
            Console.WriteLine("Cadastrar Funcionário - 2");
            Console.WriteLine("Atualizar dados do funcionario - 3");
            Console.WriteLine("Deletar um funcionário - 4");
            Console.WriteLine("Consultar a folha de pagamento - 5");
            Console.WriteLine("Sair - q");
            string op = Console.ReadLine();
            escolha(op);

        } // Inserir o menu da folha de pagamento e a atualização  dentro do exibir, e deixar só o delete nesse menu
        public void escolha(string opcao)
        {
            string nomeFunc;
            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Qual funcionário você quer consultar? (digite o nome)");
                    nomeFunc = Console.ReadLine();
                    carregarDadosDoBanco(nomeFunc);
                    exibir(nomeFunc);
                    menuFunc();
                    break;
                case "2":
                    cadastro();
                    break;
                case "3":
                    Console.WriteLine("Qual funcionário você quer atualizar? (digite o nome)");
                    nomeFunc = Console.ReadLine();
                    atualizar(nomeFunc);
                    break;
                case "4":
                    Console.WriteLine("Qual funcionário você quer deletar? (digite o nome)");
                    nomeFunc = Console.ReadLine();
                    deletarFunc(nomeFunc);
                    break;
                case "5":

                case "q":
                    Thread.Sleep(1000);
                    Console.Clear() ;
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        public void exibir(string nome)
        {
            bool alterar = false;
            string escolha;
            Console.WriteLine("Id: {0}", this.IdFunc);
            Console.WriteLine("Nome: {0}",this.Nome);
            Console.WriteLine("Cargo: {0}",this.Cargo);
            Console.WriteLine("Tel_C: {0}",this.Tel_C);
            Console.WriteLine("Email: {0}",this.Email);
            Console.WriteLine("Data_de_Contratação: {0}",this.Data_de_Contratacao);

            Console.WriteLine("Deseja fazer alguma alteraçao ou consultar a folha de pagamento do funcionario?/n");
            alterar = Console.ReadLine().Equals("s");
            if (alterar)
            {
                Console.WriteLine("alterar - 1");
                Console.WriteLine("consultar - 2");
                escolha= Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        atualizar(nome);
                        break;
                    case "2":
                        folha_Pagamento();
                        break;

                }

            }else
            { Console.WriteLine("\nAperte qualquer tecla para voltar"); }
            


            Console.ReadKey();
        }

        public void cadastro()
        {
            Console.WriteLine("Qual o nome do funcionario?");
            this.Nome = Console.ReadLine();
            Console.WriteLine("Qual o cargo do funcionario?");
            this.Cargo = Console.ReadLine();
            Console.WriteLine("Qual o telefone do funcionario?");
            this.Tel_C= Console.ReadLine();
            Console.WriteLine("Qual o email do funcionario?");
            this.Email= Console.ReadLine();
            Console.WriteLine("Qualfoi a data de contratação do funcionario?");
            this.Data_de_Contratacao = Console.ReadLine();

            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                try
                {
                    connection.Open();


                    string query = "INSERT INTO `restaurante`.`Funcionario` (`idEstabelecimento`, `Nome`, `Cargo`,`Tel_C`,`Email`,`Data_de_Contratacao`) VALUES ('1',@nome,@cargo,@telefone,@email,@data_de_contratacao);";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nome", this.Nome);
                    cmd.Parameters.AddWithValue("@cargo", this.Cargo);
                    cmd.Parameters.AddWithValue("@telefone", this.Tel_C);
                    cmd.Parameters.AddWithValue("@email", this.Email);
                    cmd.Parameters.AddWithValue("@data_de_contratacao", this.Data_de_Contratacao);


                    int linhasAfetadas = cmd.ExecuteNonQuery();


                    if (linhasAfetadas > 0)
                    {
                        Console.WriteLine("funcionario atualizado com sucesso.");
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
        public void atualizar(string nomeAt)
        {
            Console.WriteLine("O que você quer atualizar?");
            Console.WriteLine("Todas as informações -1");
            Console.WriteLine("Cargo - 2");
            Console.WriteLine("Tel_C - 3");
            Console.WriteLine("Email - 4");
            Console.WriteLine("");

            string op = Console.ReadLine();
            switch (op)
            {
                case "1":
                    atualizaTudo(nomeAt);
                    break;
                case "2":
                    Console.WriteLine("Digite o novo cargo");
                    string cargo = Console.ReadLine();
                    this.Cargo = cargo;

                    using (MySqlConnection connection = new MySqlConnection(conexao))
                    {
                        try
                        {
                            connection.Open();


                            string query = "update funcionario set cargo = @cargo where Nome = @nome";
                            MySqlCommand cmd = new MySqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@cargo", this.Cargo);
                            cmd.Parameters.AddWithValue("@nome", nomeAt);
                           

                            int linhasAfetadas = cmd.ExecuteNonQuery();


                            if (linhasAfetadas > 0)
                            {
                                Console.WriteLine("Funcionario atualizado com sucesso.");
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

                    break;
                case "3":
                    Console.WriteLine("Qual o novo numero de telefone?");
                    string telefone = Console.ReadLine();
                    this.Tel_C = telefone;

                    using (MySqlConnection connection = new MySqlConnection(conexao))
                    {
                        try
                        {
                            connection.Open();


                            string query = "update funcionario set Tel_C = @telefone where Nome = @nome";
                            MySqlCommand cmd = new MySqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@telefone", this.Tel_C);
                            cmd.Parameters.AddWithValue("@nome", nomeAt);

                            int linhasAfetadas = cmd.ExecuteNonQuery();


                            if (linhasAfetadas > 0)
                            {
                                Console.WriteLine("Funcionario atualizado com sucesso.");
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
                    break;
                case "4":
                    Console.WriteLine("Qual o novo email?");
                    string email = Console.ReadLine();
                    this.Email = email;

                    using (MySqlConnection connection = new MySqlConnection(conexao))
                    {
                        try
                        {
                            connection.Open();


                            string query = "update funcionario set email = @email where Nome = @nome";
                            MySqlCommand cmd = new MySqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@email", this.Email);
                            cmd.Parameters.AddWithValue("@nome", nomeAt);

                            int linhasAfetadas = cmd.ExecuteNonQuery();


                            if (linhasAfetadas > 0)
                            {
                                Console.WriteLine("Funcionario atualizado com sucesso.");
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
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;

            }
        }
        public void atualizaTudo(string nomeAt)
        {
            Console.WriteLine("Digite o novo cargo");
            string cargo = Console.ReadLine();
            this.Cargo = cargo;

            Console.WriteLine("Qual o novo numero de telefone?");
            string telefone = Console.ReadLine();
            this.Tel_C = telefone;

            Console.WriteLine("Qual o novo email?");
            string email = Console.ReadLine();
            this.Email = email;

            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                try
                {
                    connection.Open();


                    string query = "update funcionario set cargo = @cargo, Tel_C = @telefone, Email = @email where Nome = @nome";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@cargo", this.Cargo);
                    cmd.Parameters.AddWithValue("@telefone", this.Tel_C);
                    cmd.Parameters.AddWithValue("@email", this.Email);
                    cmd.Parameters.AddWithValue("@nome", nomeAt);


                    int linhasAfetadas = cmd.ExecuteNonQuery();


                    if (linhasAfetadas > 0)
                    {
                        Console.WriteLine("Funcionario atualizado com sucesso.");
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
        public void deletarFunc(string nomeDel)
        {
            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                try
                {
                    connection.Open();


                    string query = "delete from funcionario where Nome = @nome";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nome", nomeDel);


                    int linhasAfetadas = cmd.ExecuteNonQuery();


                    if (linhasAfetadas > 0)
                    {
                        Console.WriteLine("Fornecedor deletado com sucesso.");
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
        public void folha_Pagamento()
        {
            //fol.conexao = this.conexao;
            fol.CarregarDadosDoBanco(this.IdFunc);
            fol.idFunc = this.IdFunc;
            fol.menuFol();
        }
        public void carregarDadosDoBanco(string nome) 
        {
            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                try
                {
                    connection.Open();


                    string query = "SELECT idFuncionario, Nome, Cargo, Tel_C, Email, Data_de_Contratacao FROM Funcionario WHERE Nome = @nome";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    /*  Console.WriteLine(id);
                      Console.ReadKey();*/

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.IdFunc = Convert.ToInt32(reader["idFuncionario"]);
                            this.Nome = reader["Nome"].ToString();
                            this.Cargo = reader["Cargo"].ToString();
                            this.Tel_C = reader["Tel_C"].ToString();
                            this.Email = reader["Email"].ToString();
                            this.Data_de_Contratacao = reader["Data_de_Contratacao"].ToString();
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
