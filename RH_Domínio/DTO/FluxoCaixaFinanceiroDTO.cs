using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_Dominio.DTO
{
    public class FluxoCaixaFinanceiroDTO
    {
        public int id { get; set; }
        public string origem { get; set; }
        public double total { get; set; }
        public DateTime datainicial { get; set; }
        public DateTime datafinal { get; set; }
        public int empresa_id { get; set; }
        public string historico { get; set; }
        public string status { get; set; }
        public string situacao { get; set; }
    }
}
