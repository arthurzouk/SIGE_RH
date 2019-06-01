using AutoMapper;
using RH_Application.ViewModels;
using RH_Banco.Context;
using RH_Banco.Repository;
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

        public IEnumerable<PessoaCurriculoViewModel> ObterPessoasAtivas()
        {
            var pessoasAtivas = Mapper.Map<IEnumerable<PessoaCurriculoViewModel>>(_pessoaCurriculoRepository.ObterOnde(x => x.Recrutamentos.Any(y => y.Aprovado && y.Situacao == "Contratado")));
            return pessoasAtivas;
        }

        public IEnumerable<PessoaCurriculoViewModel> ObterPessoasDemitidas()
        {
            var pessoasDemitidas = Mapper.Map<IEnumerable<PessoaCurriculoViewModel>>(_pessoaCurriculoRepository.ObterOnde(x => x.Demissoes.Any(y => y.QuantidadeDeFalhas > 9 || y.FalhaGrave)));
            return pessoasDemitidas;
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
    }
}
