using AutoMapper;
using RH_Application.ViewModels;
using RH_Banco.Context;
using RH_Banco.Repository;
using Services_API.Financeiro.ApiService;
using Services_API.Marketing.ApiService;
using Services_API.Producao.ApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RH_Application.AppServices
{
    public class DadosRelatorioAppService
    {
        private RecursosHumanosContext _context;
        private PessoaCurriculoRepository _pessoaCurriculoRepository;
        private RecrutamentoRepository _recrutamentoRepository;
        private ProducaoApiService _producaoApiService;
        private MarketingApiService _marketingApiService;
        private FinanceiroApiService _financeiroApiService;

        public DadosRelatorioAppService()
        {
            _context = new RecursosHumanosContext();
            _pessoaCurriculoRepository = new PessoaCurriculoRepository(_context);
            _recrutamentoRepository = new RecrutamentoRepository(_context);
            _producaoApiService = new ProducaoApiService();
            _marketingApiService = new MarketingApiService();
            _financeiroApiService = new FinanceiroApiService();
        }

        public void AgruparDados()
        {
            //Lista as pessoas - RH. Deve conter (matricula, nome da pessoa, cargo, periodoTrabalho)
            var pessoas = new List<PessoaRecrutamentoViewModel>();
            var pessoasAtivas = Mapper.Map<IEnumerable<PessoaCurriculoViewModel>>(_pessoaCurriculoRepository.ObterOnde(x => x.Recrutamentos.Any(y => y.Aprovado && y.Situacao == "Contratado")));

            foreach (var i in pessoasAtivas)
            {
                var recrutamento = Mapper.Map<RecrutamentoViewModel>(_recrutamentoRepository.ObterPrimeiroOuPadrao(x => x.PessoaCurriculoId == i.Id));
                pessoas.Add(new PessoaRecrutamentoViewModel { PessoaCurriculo = i, Recrutamento = recrutamento });
            }

            //Lista de produtos vendidos - PRODUCAO.
            //todos os produtos  https://webapiproducaov3.azurewebsites.net/api/item
            //todas as vendas https://webapiproducaov3.azurewebsites.net/api/vendas

            var listaProdutos = _producaoApiService.ObterListaProdutos();
            var listaVendas = _producaoApiService.ObterListaVendas();

            //Lista de produtos em promoção - MARKETING.
            //todos os produtos em promocao http://sigemv.ml/api/integracoes

            var listaProdutosPromocao = _marketingApiService.ObterListaProdutos();

            //Lista de preços dos produtos - FINANCEIRO
            //Fluxo de caixa http://sigefinanceiroapi.azurewebsites.net/Financeiro/GetFluxoDeCaixa

            var fluxoCaixa = _financeiroApiService.ObterFluxoCaixa();
        }

        public List<RelatorioOperacionalViewModel> GetDadosOperacional()
        {
            AgruparDados();
            var listaDadosOperacional = new List<RelatorioOperacionalViewModel>();





            //{
            //    new DadosOperacional { Matricula=01, Cargo="Estágiário Operador de caixa", Funcionario="Heloisa Sousa", Jornada= "06:00", Periodo= "M", QuantidadeVencida=165, VolumeFinanceiro="R$ 1,155.00"},
            //    new DadosOperacional { Matricula=02, Cargo="Operador de caixa", Funcionario="Vanessa Marques", Jornada= "08:00", Periodo= "V", QuantidadeVencida=127, VolumeFinanceiro="R$ 889.00"},
            //    new DadosOperacional { Matricula=03, Cargo="Operador de caixa", Funcionario="Letícia Fonseca", Jornada= "08:00", Periodo= "N", QuantidadeVencida=135, VolumeFinanceiro="R$ 945.00"},
            //    new DadosOperacional { Matricula=04, Cargo="Estágiário Operador de caixa", Funcionario="Leonardo Carvalho", Jornada= "06:00", Periodo="M", QuantidadeVencida=66, VolumeFinanceiro="R$ 462.00"},
            //    new DadosOperacional { Matricula=05, Cargo="Estágiário Operador de caixa", Funcionario="Thais Santots", Jornada= "06:00", Periodo="M", QuantidadeVencida=82, VolumeFinanceiro="R$ 574.00"},
            //    new DadosOperacional { Matricula=06, Cargo="Operador de caixa", Funcionario="Lucas Fonseca", Jornada= "08:00", Periodo="M", QuantidadeVencida=186, VolumeFinanceiro="R$ 1,302.00"},
            //    new DadosOperacional { Matricula=07, Cargo="Operador de caixa", Funcionario="Karina Gomes", Jornada= "08:00", Periodo="N", QuantidadeVencida=153, VolumeFinanceiro="R$ 1,071.00"},
            //    new DadosOperacional { Matricula=08, Cargo="Operador de caixa", Funcionario="Gláucia Franco", Jornada= "08:00", Periodo="V", QuantidadeVencida=80, VolumeFinanceiro="R$ 560.00"},
            //    new DadosOperacional { Matricula=09, Cargo="Estágiário Operador de caixa", Funcionario="Liz Castro", Jornada= "06:00", Periodo="V", QuantidadeVencida=135, VolumeFinanceiro="R$ 945.00"},
            //    new DadosOperacional { Matricula=10, Cargo="Estágiário Operador de caixa", Funcionario="Maria de Fátima", Jornada= "06:00", Periodo="V", QuantidadeVencida=179, VolumeFinanceiro="R$ 1,253.00"},
            //    new DadosOperacional { Matricula=11, Cargo="Operador de caixa", Funcionario="Solange Silva", Jornada= "08:00", Periodo="V", QuantidadeVencida=132, VolumeFinanceiro="R$ 924.00"},
            //    new DadosOperacional { Matricula=12, Cargo="Operador de caixa", Funcionario="Robson Santos", Jornada= "08:00", Periodo="M", QuantidadeVencida=151, VolumeFinanceiro="R$ 1,057.00"}
            //};
            return listaDadosOperacional;

        }

        public List<RelatorioTaticoViewModel> GetDadosTatico()
        {
            var listaDadosTatico = new List<RelatorioTaticoViewModel>();

            //{
            //    new DadosTatico { Cargo="Estágiário Operador de caixa", Funcionario="Heloisa Sousa", VolumeFinanceiro="R$ 1,155.00" , ProdutoPromocao ="A", QuantidadeVencida=165},
            //    new DadosTatico { Cargo="Operador de caixa", Funcionario="Vanessa Marques", VolumeFinanceiro="R$ 889.00", ProdutoPromocao ="A", QuantidadeVencida=127},
            //    new DadosTatico { Cargo="Operador de caixa", Funcionario="Letícia Fonseca", VolumeFinanceiro="R$ 945.00", ProdutoPromocao ="A", QuantidadeVencida=135},
            //    new DadosTatico { Cargo="Estágiário Operador de caixa", Funcionario="Leonardo Carvalho", VolumeFinanceiro="R$ 462.00", ProdutoPromocao ="B", QuantidadeVencida=66},
            //    new DadosTatico { Cargo="Estágiário Operador de caixa", Funcionario="Thais Santots", VolumeFinanceiro="R$ 574.00", ProdutoPromocao ="B", QuantidadeVencida=82},
            //    new DadosTatico { Cargo="Operador de caixa", Funcionario="Lucas Fonseca", VolumeFinanceiro="R$ 1,302.00", ProdutoPromocao ="B", QuantidadeVencida=186}
            //};
            return listaDadosTatico;

        }

        public List<RelatorioEstrategicoViewModel> GetDadosEstrategico()
        {
            var listaDadosEstrategico = new List<RelatorioEstrategicoViewModel>();


            //{
            //    new DadosEstrategico { Cargo="Estágiário Operador de caixa", CargaHoraria="600", Assiduidade="588", VolumeFinanceiro="500"},
            //    new DadosEstrategico { Cargo="Operador de caixa", CargaHoraria="800", Assiduidade="790", VolumeFinanceiro="1000"}
            //};

            return listaDadosEstrategico;

        }
    }
}