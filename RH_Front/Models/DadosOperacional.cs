using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RH_Front.Models
{
    public class DadosOperacional
    {
        public int Matricula { get; set; }
        public string Cargo { get; set; }
        public string Funcionario { get; set; }
        public string Jornada { get; set; }
        public string Periodo { get; set; }
        public int QuantidadeVencida { get; set; }
        public string VolumeFinanceiro { get; set; }
    }
}