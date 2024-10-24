using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fornecedoresLibrary
{
    public class Fornecedores
    {
        public int Idforn {  get; set; }
        public string Logradouro {  get; set; }
        public string Cnpj {  get; set; }

        public string Complemento { get; set; }
        public string Cep {get; set; }
        public string Tel_C {  get; set; }
        public string Tempo_Contrato { get; set; }
    }
}
