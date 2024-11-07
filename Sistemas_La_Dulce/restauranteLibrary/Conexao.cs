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
        public string sql = "";
        public MySqlCommand cmd = new MySqlCommand();
        
        public void conn()
        {
   
            try
            {
                string stringconexao = "server= 127.0.0.1;uid=root;pwd='';database=restaurante";
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
           

        }

        public void comando(string tabela, object conexao)
        {
            cmd.CommandText = "insert into "+tabela+"";
        }
    }

    
}
