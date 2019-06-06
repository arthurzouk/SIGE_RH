using AutoMapper;
using RH_Application.ViewModels;
using RH_Banco.Context;
using RH_Banco.Repository;
using Services_API.Financeiro.ApiService;
using Services_API.Marketing.ApiService;
using Services_API.Producao.ApiService;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private List<DadosRelatoriosViewModel> _todosOsDados;

        public DadosRelatorioAppService()
        {
            _context = new RecursosHumanosContext();
            _pessoaCurriculoRepository = new PessoaCurriculoRepository(_context);
            _recrutamentoRepository = new RecrutamentoRepository(_context);
            _producaoApiService = new ProducaoApiService();
            _marketingApiService = new MarketingApiService();
            _financeiroApiService = new FinanceiroApiService();
            _todosOsDados = new List<DadosRelatoriosViewModel>();
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
            //Fluxo de caixa http://sigefinanceiroapi.azurewebsites.net/Financeiro/LucroPorProduto

            var lucroPorProdutos = _financeiroApiService.ObterLucroPorProduto();

            DadosRelatoriosViewModel dado;

            string CPF;
            string Nome;
            string Cargo;
            string PeriodoTrabalho;
            string nomeprod;
            string valorRealParaEmpresa;
            bool isPromotion;

            for (int i = 0; i < listaVendas.Count; i++)
            {
                CPF = string.Empty;
                Nome = string.Empty;
                Cargo = string.Empty;
                PeriodoTrabalho = string.Empty;
                nomeprod = string.Empty;
                valorRealParaEmpresa = string.Empty;
                isPromotion = false;



                for (int j = 0; j < listaProdutosPromocao.Count; j++)
                {
                    if (listaVendas[i].codprod == listaProdutosPromocao[j].ID)
                    {
                        //armazenar dados da venda
                        isPromotion = true;
                        break;
                    }
                }

                try
                {
                    if (isPromotion)
                    {
                        for (int j = 0; j < listaProdutos.Count; j++)
                        {
                            if (listaVendas[i].codprod == listaProdutos[j].codprod)
                            {
                                //armazenar dados do produto
                                nomeprod = listaProdutos[j].nomeprod;
                                break;
                            }
                        }

                        for (int j = 0; j < pessoas.Count; j++)
                        {
                            //armazenar dados do operador

                            //if (listaVendas[i].idOperador.ToString() == pessoas[j].PessoaCurriculo.Id)
                            //{
                            //CPF = pessoas[j].PessoaCurriculo.CPF;
                            //Nome = pessoas[j].PessoaCurriculo.Nome;
                            //Cargo = pessoas[j].Recrutamento.Cargo;
                            //PeriodoTrabalho = pessoas[j].Recrutamento.PeriodoTrabalho;
                            //break;
                            //}

                            CPF = pessoas[i].PessoaCurriculo.CPF;
                            Nome = pessoas[i].PessoaCurriculo.Nome;
                            Cargo = pessoas[i].Recrutamento.Cargo;
                            PeriodoTrabalho = pessoas[i].Recrutamento.PeriodoTrabalho;
                        }

                        for (int j = 0; j < lucroPorProdutos.Count; j++)
                        {
                            if (listaVendas[i].codprod == lucroPorProdutos[j].idProduto)
                            {
                                //armazenar dados do lucro real
                                valorRealParaEmpresa = lucroPorProdutos[j].valorRealParaEmpresa;
                                break;
                            }
                        }

                        dado = new DadosRelatoriosViewModel()
                        {
                            CPF = CPF,
                            Nome = Nome,
                            Cargo = Cargo,
                            PeriodoTrabalho = PeriodoTrabalho,
                            nomeprod = nomeprod,
                            valorRealParaEmpresa = valorRealParaEmpresa,
                            dtvenda = listaVendas[i].dtvenda,
                            qtdvenda = listaVendas[i].qtdvenda
                        };

                        _todosOsDados.Add(dado);
                    }
                }
                catch (Exception)
                {

                }

            }


        }

        public List<RelatorioOperacionalViewModel> GetDadosOperacional()
        {
            AgruparDados();

            var listaDadosOperacional = new List<RelatorioOperacionalViewModel>();

            RelatorioOperacionalViewModel dadoOperacional;

            for (int i = 0; i < _todosOsDados.Count; i++)
            {
                dadoOperacional = new RelatorioOperacionalViewModel()
                {
                    CPF = _todosOsDados[i].CPF,
                    Cargo = _todosOsDados[i].Cargo,
                    Funcionario = _todosOsDados[i].Nome,
                    Jornada = _todosOsDados[i].Cargo == "estagiario" ? "06:00" : "08:00",
                    Periodo = _todosOsDados[i].PeriodoTrabalho.ToUpper(),
                    QuantidadeVendida = _todosOsDados[i].qtdvenda,
                    Produto = _todosOsDados[i].nomeprod,
                    VolumeFinanceiro = (_todosOsDados[i].qtdvenda * Double.Parse(_todosOsDados[i].valorRealParaEmpresa.Replace("$", ""))).ToString("C", CultureInfo.CurrentCulture),
                    data = _todosOsDados[i].dtvenda
                };

                listaDadosOperacional.Add(dadoOperacional);
            }


            return listaDadosOperacional;

        }

        public List<RelatorioTaticoViewModel> GetDadosTatico()
        {
            AgruparDados();

            var listaDadosTatico = new List<RelatorioTaticoViewModel>();

            RelatorioTaticoViewModel dadoTatico;

            for (int i = 0; i < _todosOsDados.Count; i++)
            {
                dadoTatico = new RelatorioTaticoViewModel()
                {
                    Cargo = _todosOsDados[i].Cargo,
                    Funcionario = _todosOsDados[i].Nome,
                    ProdutoPromocao = _todosOsDados[i].nomeprod,
                    QuantidadeVendida = _todosOsDados[i].qtdvenda,
                    VolumeFinanceiro = (_todosOsDados[i].qtdvenda * Double.Parse(_todosOsDados[i].valorRealParaEmpresa.Replace("$", ""))).ToString("C", CultureInfo.CurrentCulture),
                    data = _todosOsDados[i].dtvenda
                };

                listaDadosTatico.Add(dadoTatico);
            }

            return listaDadosTatico;

        }

        public List<RelatorioEstrategicoViewModel> GetDadosEstrategico()
        {
            AgruparDados();

            var listaDadosEstrategico = new List<RelatorioEstrategicoViewModel>();

            RelatorioEstrategicoViewModel dadoEstrategico;
            string cargo;
            string cargaHoraria;
            string assiduidade;
            double volumeFinanceiro;

            string auxCargo = string.Empty;
            int qtdCargos = 0;

            for (int i = 0; i < _todosOsDados.Count; i++)
            {
                if (auxCargo == string.Empty
                    || !auxCargo.Contains(_todosOsDados[i].Cargo))
                {
                    auxCargo += _todosOsDados[i].Cargo + "|";
                    qtdCargos++;
                }
            }

            string[] auxCargos = auxCargo.Split('|');

            for (int i = 0; i < qtdCargos; i++)
            {
                cargo = string.Empty;
                cargaHoraria = string.Empty;
                assiduidade = string.Empty;
                volumeFinanceiro = 0;

                for (int j = 0; j < _todosOsDados.Count; j++)
                {
                    if (auxCargos[i].Contains(_todosOsDados[j].Cargo))
                    {
                        cargo = _todosOsDados[j].Cargo;
                        cargaHoraria = "600";
                        assiduidade = "580";
                        volumeFinanceiro = volumeFinanceiro + (_todosOsDados[j].qtdvenda * Double.Parse(_todosOsDados[j].valorRealParaEmpresa.Replace("$", "")));
                    }
                }

                dadoEstrategico = new RelatorioEstrategicoViewModel()
                {
                    Cargo = cargo,
                    CargaHoraria = cargaHoraria,
                    Assiduidade = assiduidade,
                    VolumeFinanceiro = volumeFinanceiro.ToString("C", CultureInfo.CurrentCulture)
                };

                listaDadosEstrategico.Add(dadoEstrategico);
            }

            //for (int i = 0; i < _todosOsDados.Count; i++)
            //{
            //    if (_todosOsDados[i].Cargo == "estagiario")
            //    {

            //    }

            //    dadoEstrategico = new RelatorioEstrategicoViewModel()
            //    {
            //        Cargo = _todosOsDados[i].Cargo,
            //        VolumeFinanceiro = (_todosOsDados[i].qtdvenda * Double.Parse(_todosOsDados[i].valorRealParaEmpresa.Replace("$", ""))).ToString("C", CultureInfo.CurrentCulture),
            //        data = _todosOsDados[i].dtvenda
            //    };

            //    listaDadosEstrategico.Add(dadoEstrategico);
            //}

            //{
            //    new DadosEstrategico { Cargo="Estágiário Operador de caixa", CargaHoraria="600", Assiduidade="588", VolumeFinanceiro="500"},
            //    new DadosEstrategico { Cargo="Operador de caixa", CargaHoraria="800", Assiduidade="790", VolumeFinanceiro="1000"}
            //};

            return listaDadosEstrategico;

        }
    }
}