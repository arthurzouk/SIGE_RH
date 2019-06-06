using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RH_Application.ViewModels
{
    public class RelatorioTaticoViewModel
    {
        public string Cargo { get; set; }
        public string Funcionario { get; set; }
        public string VolumeFinanceiro { get; set; }
        public string ProdutoPromocao { get; set; }
        public int QuantidadeVendida { get; set; }
        public string data { get; set; }
    }
}