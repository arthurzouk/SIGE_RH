using RH_Front.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RH_Front.Services
{
    public class DadosServices
    {
        public static List<DadosOperacional> GetDadosOperacional()
        {
            var listaDados = new List<DadosOperacional>()
            {
                new DadosOperacional { Matricula=01, Cargo="Estágiário Operador de caixa", Funcionario="Heloisa Sousa", Jornada= "06:00", Periodo= "M", QuantidadeVencida=165, VolumeFinanceiro="R$ 1,155.00"},
                new DadosOperacional { Matricula=02, Cargo="Operador de caixa", Funcionario="Vanessa Marques", Jornada= "08:00", Periodo= "V", QuantidadeVencida=127, VolumeFinanceiro="R$ 889.00"},
                new DadosOperacional { Matricula=03, Cargo="Operador de caixa", Funcionario="Letícia Fonseca", Jornada= "08:00", Periodo= "N", QuantidadeVencida=135, VolumeFinanceiro="R$ 945.00"},
                new DadosOperacional { Matricula=04, Cargo="Estágiário Operador de caixa", Funcionario="Leonardo Carvalho", Jornada= "06:00", Periodo="M", QuantidadeVencida=66, VolumeFinanceiro="R$ 462.00"},
                new DadosOperacional { Matricula=05, Cargo="Estágiário Operador de caixa", Funcionario="Thais Santots", Jornada= "06:00", Periodo="M", QuantidadeVencida=82, VolumeFinanceiro="R$ 574.00"},
                new DadosOperacional { Matricula=06, Cargo="Operador de caixa", Funcionario="Lucas Fonseca", Jornada= "08:00", Periodo="M", QuantidadeVencida=186, VolumeFinanceiro="R$ 1,302.00"},
                new DadosOperacional { Matricula=07, Cargo="Operador de caixa", Funcionario="Karina Gomes", Jornada= "08:00", Periodo="N", QuantidadeVencida=153, VolumeFinanceiro="R$ 1,071.00"},
                new DadosOperacional { Matricula=08, Cargo="Operador de caixa", Funcionario="Gláucia Franco", Jornada= "08:00", Periodo="V", QuantidadeVencida=80, VolumeFinanceiro="R$ 560.00"},
                new DadosOperacional { Matricula=09, Cargo="Estágiário Operador de caixa", Funcionario="Liz Castro", Jornada= "06:00", Periodo="V", QuantidadeVencida=135, VolumeFinanceiro="R$ 945.00"},
                new DadosOperacional { Matricula=10, Cargo="Estágiário Operador de caixa", Funcionario="Maria de Fátima", Jornada= "06:00", Periodo="V", QuantidadeVencida=179, VolumeFinanceiro="R$ 1,253.00"},
                new DadosOperacional { Matricula=11, Cargo="Operador de caixa", Funcionario="Solange Silva", Jornada= "08:00", Periodo="V", QuantidadeVencida=132, VolumeFinanceiro="R$ 924.00"},
                new DadosOperacional { Matricula=12, Cargo="Operador de caixa", Funcionario="Robson Santos", Jornada= "08:00", Periodo="M", QuantidadeVencida=151, VolumeFinanceiro="R$ 1,057.00"}
            };
            return listaDados;
 
        }

        public static List<DadosTatico> GetDadosTatico()
        {
            var listaDados = new List<DadosTatico>()
            {
                new DadosTatico { Cargo="Estágiário Operador de caixa", Funcionario="Heloisa Sousa", VolumeFinanceiro="R$ 1,155.00" , ProdutoPromocao ="A", QuantidadeVencida=165},
                new DadosTatico { Cargo="Operador de caixa", Funcionario="Vanessa Marques", VolumeFinanceiro="R$ 889.00", ProdutoPromocao ="A", QuantidadeVencida=127},
                new DadosTatico { Cargo="Operador de caixa", Funcionario="Letícia Fonseca", VolumeFinanceiro="R$ 945.00", ProdutoPromocao ="A", QuantidadeVencida=135},
                new DadosTatico { Cargo="Estágiário Operador de caixa", Funcionario="Leonardo Carvalho", VolumeFinanceiro="R$ 462.00", ProdutoPromocao ="B", QuantidadeVencida=66},
                new DadosTatico { Cargo="Estágiário Operador de caixa", Funcionario="Thais Santots", VolumeFinanceiro="R$ 574.00", ProdutoPromocao ="B", QuantidadeVencida=82},
                new DadosTatico { Cargo="Operador de caixa", Funcionario="Lucas Fonseca", VolumeFinanceiro="R$ 1,302.00", ProdutoPromocao ="B", QuantidadeVencida=186}
            };
            return listaDados;

        }

        public static List<DadosEstrategico> GetDadosEstrategico()
        {
            var listaDados = new List<DadosEstrategico>()
            {
                new DadosEstrategico { Cargo="Estágiário Operador de caixa", CargaHoraria="600", Assiduidade="588", VolumeFinanceiro="500"},
                new DadosEstrategico { Cargo="Operador de caixa", CargaHoraria="800", Assiduidade="790", VolumeFinanceiro="1000"}
            };
            return listaDados;

        }
    }
}