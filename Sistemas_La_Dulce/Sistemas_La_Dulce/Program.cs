﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using restauranteLibrary;
namespace Sistemas_La_Dulce
{
    internal class Program
    {
       static void Main(string[] args)
        {

            string stringconexao = "server=127.0.0.1;uid=root;pwd='';database=restaurante";
            MySqlConnection conexao;
            conexao = new MySqlConnection();
            try
            {

                conexao.ConnectionString = stringconexao;
                conexao.Open();
                Console.WriteLine("Conexão estabelecida");
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro gerado" + ex.Message);
                Console.WriteLine("Erro! entre em contato com o administrador");
                Console.ReadKey();
            }

            string op;
            Console.WriteLine("RESTAURANTE LA DULCE\n\n");
            Console.WriteLine("Onde você deseja ir?\n");
            Console.WriteLine("Estoque-1\n");
            Console.WriteLine("Financeiro-2\n");
            Console.WriteLine("Fornecedores-3\n");
            Console.WriteLine("Reservas-4\n");
            Console.WriteLine("Recursos Humanos-5\n");
            Console.WriteLine("Sair-q");
            op =Console.ReadLine();
             Menu m= new Menu();
            Balanco_patrimonial b = new Balanco_patrimonial();
            Estoque e = new Estoque(stringconexao);
            Fornecedores f = new Fornecedores();
            bool rodando = true;

            while (rodando)
            {
                switch (m.painel())
                {
                    case "1":
                        Console.Clear();
                        e.menuestoque();
                        break;
                    case "2":
                        Console.Clear();
                        b.verificacao();
                        break;
                    case "3":
                        Console.Clear();
                        f.MenuForn();
                        break;
                    case "4":
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        break;
                    case "q":
                        rodando = false;
                        Console.WriteLine("Encerrando");
                        Thread.Sleep(500);
                        break;
                }
            }
        }
    }
}
