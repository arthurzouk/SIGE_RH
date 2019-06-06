using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RH_Application.ViewModels
{
    public class RelatorioOperacionalViewModel
    {
        public string CPF { get; set; }
        public string Cargo { get; set; }
        public string Funcionario { get; set; }
        public string Jornada { get; set; }
        public string Periodo { get; set; }
        public int QuantidadeVendida { get; set; }
        public string Produto { get; set; }
        public string VolumeFinanceiro { get; set; }
        public string data { get; set; }
    }
}