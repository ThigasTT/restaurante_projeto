﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace restauranteLibrary
{
    public class Folha_pag
    {
        public int idFolha { get; set; }
        public int idFunc { get; set; }
        public double Salario_base { get; set; }
        public double Salario_final { get; set; }
        public double Salario_aux { get; set; }
        public int Faltas { get; set; }
        public double Atrasos { get; set; }
        public double Hora_Extra { get; set; }
        public double aumentoHE { get; set; }//porcentagem de aumento da he
        public int Jornada_Mes { get; set; }
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
            Console.WriteLine("\nListar todos os holerites -1");
            Console.WriteLine("Consultar a folha de pagamento - 2");
            Console.WriteLine("criar nova folha de pagamento - 3");
            Console.WriteLine("Atualizar folha de pagamento - 4");
            Console.WriteLine("Sair - q");

            op = Console.ReadLine();
            escolha(op);
        }

        public void escolha(string opcao)
        {
            switch (opcao)
            {
                case "1":
                    ListarFol();
                    break;
                case "2":
                    exibir();
                    break;
                case "3":
                    criaFolha();
                    break;

                case "4":
                    atFolha();
                    break;
                case "q":
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("opção inválida");
                    break;
            }
        }

        public void exibir()
        {
            Console.WriteLine("idFolha: {0}", this.idFolha);
            Console.WriteLine("idFunc: {0}",this.idFunc);
            Console.WriteLine("Salario base: {0:f2}",this.Salario_base);
            Console.WriteLine("Salario final: {0:f2}",this.Salario_final);
            Console.WriteLine("Faltas: {0}", this.Faltas);
            Console.WriteLine("Atrasos: {0:f2} horas",this.Atrasos);
            Console.WriteLine("Horas extras: {0:f2} horas",this.Hora_Extra);
            Console.WriteLine("Data da folha de pagamento: {0}\n",this.Data_folha);
            Console.WriteLine("Aperte qualquer tecla para sair");
            Console.ReadKey();
            Console.Clear();
            menuFol();
        }
        public void criaFolha()
        {
            Console.WriteLine("Digite o salario base");
            this.Salario_base = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o numero de faltas");
            this.Faltas = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite as horas de atrasos");
            this.Atrasos = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite quantas horas extras o empregado fez");
            this.Hora_Extra = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite a porcentagem de aumento (sem o simbolo de porcentagem");
             this.aumentoHE = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a jornada mensal do funcionario");
            this.Jornada_Mes = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o mês e o ano referente à essa folha ex: mm/aaaa");
            this.Data_folha = Console.ReadLine();
            /*calculoDescontos();
            calculoHE(aumento);*/
            calculoDesAndAum(this.aumentoHE);


            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                try
                {
                    connection.Open();


                    string query = "INSERT INTO Folha_Pag (`idFuncionario`,`idEstabelecimento`, `Salario_base`,`Salario_final`,`Faltas`,`Atrasos`,`Hora_Extra`,`Jornada_Mes`,`Data_folha`) VALUES (@idFunc,1,@Sal_base,@Sal_final,@Faltas,@Atrasos,@HE,@Jornada_Mes,@data_fol);";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@idFunc", this.idFunc);
                    cmd.Parameters.AddWithValue("@Sal_base", this.Salario_base);
                    cmd.Parameters.AddWithValue("@Sal_final", this.Salario_final);
                    cmd.Parameters.AddWithValue("@Faltas", this.Faltas);
                    cmd.Parameters.AddWithValue("@Atrasos", this.Atrasos);
                    cmd.Parameters.AddWithValue("@HE", this.Hora_Extra);
                    cmd.Parameters.AddWithValue("@Jornada_Mes", this.Jornada_Mes);
                    cmd.Parameters.AddWithValue("@data_fol", this.Data_folha);



                    int linhasAfetadas = cmd.ExecuteNonQuery();


                    if (linhasAfetadas > 0)
                    {
                        Console.WriteLine("folha de pagamento criada com sucesso.");
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

            Thread.Sleep(1000);
            menuFol();
        }

        public void atFolha()
        {
            string op;
            Console.WriteLine("O que você quer atualizar?");
            Console.WriteLine("tudo - 1");
            Console.WriteLine("Faltas - 2");
            Console.WriteLine("Atrasos - 3");
            Console.WriteLine("Horas extras - 4\n");
            Console.WriteLine("Mudar a jornada mensal - 5");
            Console.WriteLine("Sair - q");
            op = Console.ReadLine();
            escolhaAt(op);
        }
        public void escolhaAt(string op)
        {
            switch (op)
            {
                case "1":
                    Console.WriteLine("Digite o numero de faltas");
                    this.Faltas = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite as horas de atrasos ");
                    this.Atrasos = double.Parse(Console.ReadLine());
                    Console.WriteLine("Digite quantas horas extras o empregado fez");
                    this.Hora_Extra = double.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a porcentagem de aumento da hora extra (sem o simbolo)");
                    this.aumentoHE = double.Parse(Console.ReadLine());
                    calculoDesAndAum(this.aumentoHE);

                    using (MySqlConnection connection = new MySqlConnection(conexao))
                    {
                        try
                        {
                            connection.Open();


                            string query = "update Folha_Pag set Faltas = @falta, Atrasos = @atrasos, Hora_Extra = @Hora_extra where idFolha_Pag = @idfolha";
                            MySqlCommand cmd = new MySqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@falta", this.Faltas);
                            cmd.Parameters.AddWithValue("@atrasos", this.Atrasos);
                            cmd.Parameters.AddWithValue("@Hora_extra", this.Hora_Extra);
                            cmd.Parameters.AddWithValue("@idfolha", this.idFolha);


                            int linhasAfetadas = cmd.ExecuteNonQuery();


                            if (linhasAfetadas > 0)
                            {
                                Console.WriteLine("folha de pagamento atualizada com sucesso.");
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
                    Thread.Sleep(1000);

                    break;

                case "2":
                    Console.WriteLine("Digite o numero de faltas");
                    this.Faltas = int.Parse(Console.ReadLine());
                   // calculoDescontos();
                    calculoDesAndAum(this.aumentoHE);

                    using (MySqlConnection connection = new MySqlConnection(conexao))
                    {
                        try
                        {
                            connection.Open();


                            string query = "update Folha_Pag set Faltas = @falta where idFolha_Pag = @idfolha";
                            MySqlCommand cmd = new MySqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@falta", this.Faltas);
                            cmd.Parameters.AddWithValue("@idfolha", this.idFolha);

                            int linhasAfetadas = cmd.ExecuteNonQuery();


                            if (linhasAfetadas > 0)
                            {
                                Console.WriteLine("folha de pagamento atualizada com sucesso.");
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
                    Thread.Sleep(1000);
                    break;
                case "3":
                    Console.WriteLine("Digite as horas de atrasos");
                    this.Atrasos = double.Parse(Console.ReadLine());
                    //calculoDescontos();
                    using (MySqlConnection connection = new MySqlConnection(conexao))
                    {
                        try
                        {
                            connection.Open();


                            string query = "update Folha_Pag set Atrasos = @atraso where idFolha_Pag = @idfolha";
                            MySqlCommand cmd = new MySqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@atraso", this.Atrasos);
                            cmd.Parameters.AddWithValue("@idfolha", this.idFolha);

                            int linhasAfetadas = cmd.ExecuteNonQuery();


                            if (linhasAfetadas > 0)
                            {
                                Console.WriteLine("folha de pagamento atualizada com sucesso.");
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
                    Thread.Sleep(1000);
                    break;
                case "4":
                    Console.WriteLine("Digite quantas horas extras o empregado fez (em minutos)");
                    this.Hora_Extra = double.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a porcentagem de aumento de cada hora extra (não precisa do simbolo)");
                    this.aumentoHE = double.Parse(Console.ReadLine());
                    //calculoHE(this.aumentoHE);
                    calculoDesAndAum(this.aumentoHE);
                    using (MySqlConnection connection = new MySqlConnection(conexao))
                    {
                        try
                        {
                            connection.Open();


                            string query = "update Folha_Pag set Hora_Extra = @he where idFolha_Pag = @idfolha";
                            MySqlCommand cmd = new MySqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@he", this.Hora_Extra);
                            cmd.Parameters.AddWithValue("@idfolha", this.idFolha);

                            int linhasAfetadas = cmd.ExecuteNonQuery();


                            if (linhasAfetadas > 0)
                            {
                                Console.WriteLine("folha de pagamento atualizada com sucesso.");
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
                    Thread.Sleep(1000);
                    break;
                case "5":
                    Console.WriteLine("Digite a nova jornada mensal do funcionario");
                    this.Jornada_Mes = int.Parse(Console.ReadLine());

                    using (MySqlConnection connection = new MySqlConnection(conexao))
                    {
                        try
                        {
                            connection.Open();


                            string query = "update Folha_Pag set Jornada_Mes = @jornadaMes where idFolha_Pag = @idfolha";
                            MySqlCommand cmd = new MySqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@jornadaMes", this.Jornada_Mes);
                            cmd.Parameters.AddWithValue("@idfolha", this.idFolha);

                            int linhasAfetadas = cmd.ExecuteNonQuery();


                            if (linhasAfetadas > 0)
                            {
                                Console.WriteLine("folha de pagamento atualizada com sucesso.");
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
                    Thread.Sleep(1000);
                    break;
                case "q":
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;

            }
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
                    //cmd.Parameters.AddWithValue("@dataFol", data_fol);
                    /*  Console.WriteLine(id);
                      Console.ReadKey();*/

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.idFolha = Convert.ToInt32(reader["idFolha_Pag"]);
                            this.Salario_base = Convert.ToDouble(reader["Salario_base"]);
                            this.Salario_final = Convert.ToDouble(reader["Salario_final"]);
                            this.Faltas = Convert.ToInt32(reader["Faltas"]);
                            this.Atrasos = Convert.ToDouble(reader["Atrasos"]);
                            this.Hora_Extra = Convert.ToDouble(reader["Hora_Extra"]);
                            this.Jornada_Mes = Convert.ToInt32(reader["Jornada_Mes"]);
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

        public void ListarFol()
        {
            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Folha_Pag where idFuncionario = @idFunc";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@idFunc", this.idFunc);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-15} {4,-15} {5,-25}", "Id", "Id fol", "id func", "salario final", "Jornada mensal", "Data do holerite");
                        Console.WriteLine(new string('-', 100));

                        while (reader.Read())
                        {
                            Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-15} {4,-15}|| {5,-25}",
                                reader["idFolha_Pag"], reader["idFuncionario"], reader["Salario_final"], reader["Jornada_Mes"], reader["Data_folha"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao acessar o banco de dados: " + ex.Message);
                }
                Console.WriteLine("Aperte qualquer tecla para ir ao menu");
                Thread.Sleep(1000);
                Console.WriteLine("Aperte qualquer tecla para voltar");
                Console.ReadKey();
                menuFol();
            }
        }

        //calculos

        public void calculoDescontos() //considerando que um mês tem 30 dias
        {
            double sal_hora = this.Salario_base/this.Jornada_Mes;
            double sal_dia = this.Salario_base/30;
          
            this.Salario_final = Salario_base - (sal_dia*this.Faltas + sal_dia * Atrasos);
        }

        public void calculoHE(double aumento)
        { 
            double sal_hora = this.Salario_base / this.Jornada_Mes;
            double he = sal_hora + sal_hora*(aumento/100);
            this.Salario_final = this.Salario_final + this.Hora_Extra*he;
        }

        public void calculoDesAndAum(double aumento)
        {
            double sal_hora = this.Salario_base / this.Jornada_Mes;
            double sal_dia = this.Salario_base / 30;
            double total_desc = this.Faltas * sal_dia + this.Atrasos * sal_hora;
            double he = sal_hora + sal_hora * (aumento / 100);
            double total_aum = he * this.Hora_Extra;
            this.Salario_final = this.Salario_base + total_aum - total_desc;
        }

    }
}
