using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
        public void Exibir()
        {
            Console.WriteLine("ID Fornecedor: {0}", this.Idforn);
            Console.WriteLine("Logradouro: {0}", this.Logradouro);
            Console.WriteLine("CNPJ: {0}", this.Cnpj);
            Console.WriteLine("Complemento: {0}", this.Complemento);
            Console.WriteLine("CEP: {0}", this.Cep);
            Console.WriteLine("Telefone: {0}", this.Tel_C);
            Console.WriteLine("Tempo de contrato: {0}", this.Tempo_Contrato);
        }
        public void MenuForn()
        {
            string op;
            Console.Clear();
            Console.WriteLine("Fornecedor");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("Olhar as infomações do fornecedor - 1");
            Console.WriteLine("Sair - q");
            op = Console.ReadLine();
            escolha(op);
        }

        public  void escolha(String op) 
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
    
        }
      
    }

}
