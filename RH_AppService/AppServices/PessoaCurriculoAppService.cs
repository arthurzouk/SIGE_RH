using AutoMapper;
using RH_AppService.ViewModels;
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

        public PessoaCurriculoAppService()
        {
            _context = new RecursosHumanosContext();
            _pessoaCurriculoRepository = new PessoaCurriculoRepository(_context);
        }

        public IEnumerable<PessoaCurriculoViewModel> ObterTodosCurriculos()
        {
            var retorno = Mapper.Map<IEnumerable<PessoaCurriculoViewModel>>(_pessoaCurriculoRepository.ObterTodos());
            return retorno;
        }

        public PessoaCurriculoViewModel ObterCurriculoPorIdProcessoDoRecrutamento(int idProcesso)
        {
            var retorno = Mapper.Map<PessoaCurriculoViewModel>(_pessoaCurriculoRepository.ObterPrimeiroOuPadrao(x => x.Recrutamentos.Any(y => y.IdProcesso == idProcesso)));
            return retorno;
        }
    }
}
