using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restauranteLibrary
{
    internal class Reserva
    {
        public class Reservas
        {
            public string Pedido { get; set; }
            public double Valcompra { get; set; }
            public string Nome_cli { get; set; }
            public string Tel_C_cli { get; set; }
            public string Data_reserva { get; set; }

            public string Numero_Pessoas { get; set; }
            public string Tipo_reserva { get; set; }
            public string Desc_event { get; set; }

            public string status_2 { get; set; }
        }
    }
}
