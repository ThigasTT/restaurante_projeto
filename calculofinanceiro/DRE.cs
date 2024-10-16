using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace calculoDRE
{
    public class DRE
    {

        public DRE()
        {
        }
       // MySqlCommand cmd;
       // MySqlConnection conexao = new MySqlConnection();

        public double Receita { get; set; }
        public double Custo { get; set; }
        public double Dre { get; set; }

        public void calculoDre(double receita, double custo)
        {
            this.Dre = receita - custo;

        }
    }
}
