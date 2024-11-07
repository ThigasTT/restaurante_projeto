using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace restauranteLibrary
{
    public class Conexao
    {
        public string server = "127.0.0.1";
        public string uid = "root";
        public string pwd = "";
        public string database = "restaurante";
        public MySqlConnection conexao = new MySqlConnection();

        public object conn()
        {
   
            try
            {
                string stringconexao = "server=127.0.0.1;uid=root;pwd='';database=restaurante";
                conexao.ConnectionString = stringconexao;
                conexao.Open();
                Console.WriteLine("Conexão estabelecida");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro gerado" + ex.Message);
                Console.WriteLine("Erro! entre em contato com o administrador");
                Console.ReadKey();
            }
            return conexao;
        }

       
    }
}
