﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    public class Fornecedores
    {
        public int Idforn { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Cnpj { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Tel_C { get; set; }
        public string Tempo_Contrato { get; set; }
        public string conexao;
        public void Exibir()
        {
            Console.WriteLine("ID Fornecedor: {0}", this.Idforn);
            Console.WriteLine("Nome: {0}", this.Nome);
            Console.WriteLine("Logradouro: {0}", this.Logradouro);
            Console.WriteLine("CNPJ: {0}", this.Cnpj);
            Console.WriteLine("Complemento: {0}", this.Complemento);
            Console.WriteLine("CEP: {0}", this.Cep);
            Console.WriteLine("Telefone: {0}", this.Tel_C);
            Console.WriteLine("Tempo de contrato: {0}", this.Tempo_Contrato);
            Console.ReadKey();
        }
        public void MenuForn()
        {
            string op;
            Console.Clear();
            carregarDadosDoBanco();
            Console.WriteLine("Fornecedor");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("Olhar as infomações do fornecedor - 1");
            Console.WriteLine("Cadastrar um fornecedor - 2");
            Console.WriteLine("Sair - q");
            op = Console.ReadLine();
            escolha(op);
        }

        public  void escolha(string op) 
        {
            switch (op)
            {
                case "1":
                    Exibir(); 
                    break;
                case "2":
                    cadastro();
                    break;
                case "q":
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente");
                    break;
            }
            
        }

        public void cadastro()
        {
            Console.WriteLine("Qual o nome do fornecedor?");
            this.Nome = Console.ReadLine();
            Console.WriteLine("Qual o cnpj do forncedor?");
            this.Cnpj = Console.ReadLine();
            Console.WriteLine("Qual o logradouro do fornecedor?");
            this.Logradouro = Console.ReadLine();
            Console.WriteLine("Qual o telefone do fornecedor?");
            this.Tel_C = Console.ReadLine();
            Console.WriteLine("Qual o cep do fornecedor?");
            this.Cep = Console.ReadLine();
            Console.WriteLine("Qual o tempo de contrato do fornecedor?");
            this.Tempo_Contrato = Console.ReadLine();

            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                try
                {
                    connection.Open();


                    string query = "insert into fornecedores (`Estabelecimento_idEstabelecimento`,`Nome`,`Logradouro`,`CNPJ`,`Complemento`,`CEP`,`Tel_C`,`Tempo_Contrato`)" +
                        " values (1,@nome,@Logradouro,@CNPJ,@Complemento,@CEP,@Tel_C,@Tempo_Contrato);";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Nome", this.Nome);
                    cmd.Parameters.AddWithValue("@Logradouro", this.Logradouro);
                    cmd.Parameters.AddWithValue("@CNPJ", this.Cnpj);
                    cmd.Parameters.AddWithValue("@Complemento", this.Complemento);
                    cmd.Parameters.AddWithValue("@CEP", this.Cep);
                    cmd.Parameters.AddWithValue("@Tel_C", this.Tel_C);
                    cmd.Parameters.AddWithValue("@Tempo_Contrato", this.Tempo_Contrato);


                    int linhasAfetadas = cmd.ExecuteNonQuery();


                    if (linhasAfetadas > 0)
                    {
                        Console.WriteLine("Fornecedor atualizado com sucesso.");
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
            public Fornecedores(string conn)
        {
            conexao = conn;
            this.Nome = "fornecedor1";

        }
        public void carregarDadosDoBanco()
        {
            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                try
                {
                    connection.Open();
                    string query = "select idFornecedores, nome, Logradouro, CNPJ, Complemento, CEP, Tel_C, Tempo_Contrato from fornecedores where Nome = @nome";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nome", this.Nome);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.Idforn = Convert.ToInt32(reader["idFornecedores"]);
                            this.Nome = reader["Nome"].ToString();
                            this.Logradouro = reader["Logradouro"].ToString();
                            this.Cnpj = reader["CNPJ"].ToString();
                            this.Complemento = reader["Complemento"].ToString();
                            this.Cep = reader["CEP"].ToString();
                            this.Tel_C = reader["Tel_C"].ToString();
                            this.Tempo_Contrato = reader["Tempo_Contrato"].ToString();
                        }
                        else
                        {
                            Console.WriteLine("Fornecedor não encontrado");
                        }
                    }


                }catch(Exception ex)
                {
                    Console.WriteLine("Erro ao acessar o banco de dados: " + ex.Message);
                }
            }
        }
      
    }

}
