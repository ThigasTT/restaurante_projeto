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
        public string conexao;
        public Folha_pag(string conexao)
        {
            this.conexao = conexao;
        }
    }
}
