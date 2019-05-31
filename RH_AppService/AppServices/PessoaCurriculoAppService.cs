using AutoMapper;
using RH_AppService.ViewModels;
using RH_Banco.Context;
using RH_Banco.Repository;
using System.Collections.Generic;

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

        public IEnumerable<PessoaCurriculoViewModel> ObterCurriculosDasPessoas()
        {
            var retorno = Mapper.Map<IEnumerable<PessoaCurriculoViewModel>>(_pessoaCurriculoRepository.ObterTodos());
            return retorno;
        }
    }
}
