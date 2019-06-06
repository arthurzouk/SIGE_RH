using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_Dominio.DTO
{
    public class VendaProducaoDTO
    {
        public long codprod { get; set; }
        public int qtdvenda { get; set; }
        public int vlrunit { get; set; } //verificar se vem do financeiro
        public string dtvenda { get; set; }
    }
}
