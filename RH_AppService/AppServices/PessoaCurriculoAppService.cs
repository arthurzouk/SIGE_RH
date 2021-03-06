﻿using AutoMapper;
using RH_Application.ViewModels;
using RH_Banco.Context;
using RH_Banco.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RH_Application.AppServices
{
    public class PessoaCurriculoAppService
    {
        private RecursosHumanosContext _context;
        private PessoaCurriculoRepository _pessoaCurriculoRepository;
        private RecrutamentoRepository _recrutamentoRepository;
        private DemissaoRepository _demissaoRepository;

        public PessoaCurriculoAppService()
        {
            _context = new RecursosHumanosContext();
            _pessoaCurriculoRepository = new PessoaCurriculoRepository(_context);
            _recrutamentoRepository = new RecrutamentoRepository(_context);
            _demissaoRepository = new DemissaoRepository(_context);
        }

        public IEnumerable<PessoaCurriculoViewModel> ObterTodosCurriculos()
        {
            var retorno = Mapper.Map<IEnumerable<PessoaCurriculoViewModel>>(_pessoaCurriculoRepository.ObterTodos());
            return retorno;
        }

        public PessoaCurriculoViewModel ObterCurriculoPorCpf(string cpf)
        {
            var retorno = Mapper.Map<PessoaCurriculoViewModel>(_pessoaCurriculoRepository.ObterPrimeiroOuPadrao(x => x.CPF == cpf));
            return retorno;
        }

        public IEnumerable<PessoaRecrutamentoViewModel> ObterPessoasAtivas()
        {
            var pessoasAtivas = Mapper.Map<IEnumerable<PessoaCurriculoViewModel>>(_pessoaCurriculoRepository.ObterOnde(x => x.Recrutamentos.Any(y => y.Aprovado && y.Situacao == "Contratado")));

            var retorno = new List<PessoaRecrutamentoViewModel>();
            foreach (var i in pessoasAtivas)
            {
                var recrutamento = Mapper.Map<RecrutamentoViewModel>(_recrutamentoRepository.ObterPrimeiroOuPadrao(x => x.PessoaCurriculoId == i.Id));
                retorno.Add(new PessoaRecrutamentoViewModel { PessoaCurriculo = i, Recrutamento = recrutamento });
            }
            return retorno;
        }

        public IEnumerable<PessoaDemissaoViewModel> ObterPessoasDemitidas()
        {
            var pessoasDemitidas = Mapper.Map<IEnumerable<PessoaCurriculoViewModel>>(_pessoaCurriculoRepository.ObterOnde(x => x.Demissoes.Any(y => y.QuantidadeDeFalhas > 9 || y.FalhaGrave)));

            var retorno = new List<PessoaDemissaoViewModel>();
            foreach (var i in pessoasDemitidas)
            {
                var demissao = Mapper.Map<DemissaoViewModel>(_demissaoRepository.ObterPrimeiroOuPadrao(x => x.PessoaCurriculoId == i.Id));
                retorno.Add(new PessoaDemissaoViewModel { PessoaCurriculo = i, Demissao = demissao });
            }
            return retorno;
        }

        public PessoaRecrutamentoViewModel ObterCurriculoPorIdProcessoDoRecrutamento(int idProcesso)
        {
            var pessoa = Mapper.Map<PessoaCurriculoViewModel>(_pessoaCurriculoRepository.ObterPrimeiroOuPadrao(x => x.Recrutamentos.Any(y => y.IdProcesso == idProcesso)));
            var recrutamento = Mapper.Map<RecrutamentoViewModel>(_recrutamentoRepository.ObterPrimeiroOuPadrao(x => x.IdProcesso == idProcesso));
            var pessoaRecrutamento = new PessoaRecrutamentoViewModel
            {
                PessoaCurriculo = pessoa,
                Recrutamento = recrutamento
            };
            return pessoaRecrutamento;
        }

        public PessoaDemissaoViewModel ObterCurriculoPorIdProcessoDeDemissao(int idProcesso)
        {
            var pessoa = Mapper.Map<PessoaCurriculoViewModel>(_pessoaCurriculoRepository.ObterPrimeiroOuPadrao(x => x.Demissoes.Any(y => y.IdProcesso == idProcesso)));
            var demissao = Mapper.Map<DemissaoViewModel>(_demissaoRepository.ObterPrimeiroOuPadrao(x => x.IdProcesso == idProcesso));
            var pessoaDemissao = new PessoaDemissaoViewModel
            {
                PessoaCurriculo = pessoa,
                Demissao = demissao
            };
            return pessoaDemissao;
        }

        public FuncionarioReclamacaoViewModel ObterFuncionarioReclamacao(string reclamacao)
        {
            var pessoasAtivas = ObterPessoasAtivas();
            var pessoasInativas = ObterPessoasDemitidas();

            var random = new Random();
            var melhoria = random.Next(1, 4);
            var ativoOuInativo = random.Next(0, 2);
            if (ativoOuInativo == 1)
            {
                var tamanhoLista = pessoasAtivas.Count();
                var indexAleatorio = random.Next(0, tamanhoLista);
                var pessoaAtiva = pessoasAtivas.ElementAt(indexAleatorio);
                return new FuncionarioReclamacaoViewModel
                {
                    CPF = pessoaAtiva.PessoaCurriculo.CPF,
                    Nome = pessoaAtiva.PessoaCurriculo.Nome,
                    AreaFuncional = pessoaAtiva.Recrutamento.SetorSolicitante,
                    Reclamacao = reclamacao,
                    Situacao = "Ativo",
                    Melhoria = melhoria == 1 ? "Sim" : melhoria == 2 ? "Não" : "Pendente"
                };
            }
            else
            {
                var tamanhoLista = pessoasInativas.Count();
                var indexAleatorio = random.Next(0, tamanhoLista);
                var pessoaAtiva = pessoasInativas.ElementAt(indexAleatorio);
                return new FuncionarioReclamacaoViewModel
                {
                    CPF = pessoaAtiva.PessoaCurriculo.CPF,
                    Nome = pessoaAtiva.PessoaCurriculo.Nome,
                    AreaFuncional = pessoaAtiva.Demissao.SetorSolicitante,
                    Reclamacao = reclamacao,
                    Situacao = "Demitido",
                    Melhoria = melhoria == 1 ? "Sim" : melhoria == 2 ? "Não" : "Pendente"
                };
            }
        }

        public IEnumerable<FuncionarioSalarioViewModel> ObterFuncionariosPorSetor(string setor)
        {
            var pessoasDaOperacao = Mapper.Map<IEnumerable<PessoaCurriculoViewModel>>(_pessoaCurriculoRepository.ObterOnde(x => x.Recrutamentos.Any(y => y.Aprovado && y.SetorSolicitante == setor)));

            var retorno = new List<FuncionarioSalarioViewModel>();
            foreach (var i in pessoasDaOperacao)
            {
                retorno.Add(new FuncionarioSalarioViewModel
                {
                    Id = i.Id,
                    CPF = i.CPF,
                    Nome = i.Nome,
                    DataNascimento = i.DataNascimento,
                    Endereco = i.Endereco,
                    Escolaridade = i.Escolaridade,
                    Curso = i.Curso,
                    Salario = i.Salario,
                    AreaFuncional = setor
                });
            }

            return retorno;
        }

        public FuncionarioCampanhaViewModel ObterCustoDoRecursoPorCampanha(string campanha)
        {
            var pessoasAtivas = ObterPessoasAtivas();

            var random = new Random();
            var melhoria = random.Next(1, 4);

            var tamanhoLista = pessoasAtivas.Count();

            var indexAleatorio = random.Next(0, tamanhoLista);
            var pessoaAtiva = pessoasAtivas.ElementAt(indexAleatorio);
            return new FuncionarioCampanhaViewModel
            {
                Campanha = campanha,
                CPF = pessoaAtiva.PessoaCurriculo.CPF,
                Nome = pessoaAtiva.PessoaCurriculo.Nome,
                DataNascimento = pessoaAtiva.PessoaCurriculo.DataNascimento,
                Endereco = pessoaAtiva.PessoaCurriculo.Endereco,
                Escolaridade = pessoaAtiva.PessoaCurriculo.Escolaridade,
                Curso = pessoaAtiva.PessoaCurriculo.Curso,
                Salario = pessoaAtiva.PessoaCurriculo.Salario,
                AreaFuncional = pessoaAtiva.Recrutamento.SetorSolicitante
            };
        }

        public IEnumerable<FuncionarioCustoPorDiaViewModel> ObterCustoDoFuncionarioPorDia(string area)
        {
            var pessoasDaOperacao = Mapper.Map<IEnumerable<PessoaCurriculoViewModel>>(_pessoaCurriculoRepository.ObterOnde(x => x.Recrutamentos.Any(y => y.Aprovado && y.SetorSolicitante == area)));

            var retorno = new List<FuncionarioCustoPorDiaViewModel>();
            foreach (var i in pessoasDaOperacao)
            {
                retorno.Add(new FuncionarioCustoPorDiaViewModel
                {
                    Id = i.Id,
                    CPF = i.CPF,
                    Nome = i.Nome,
                    DataNascimento = i.DataNascimento,
                    Endereco = i.Endereco,
                    Escolaridade = i.Escolaridade,
                    Curso = i.Curso,
                    CustoPorDia = (i.Salario / 30),
                    AreaFuncional = area
                });
            }

            return retorno;
        }
    }
}
