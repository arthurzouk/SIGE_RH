using AutoMapper;
using RH_Application.ViewModels;
using RH_Banco.Context;
using RH_Banco.Repository;
using System.Collections.Generic;

namespace RH_Application.AppServices
{
    public class DemissaoAppService
    {
        private RecursosHumanosContext _context;
        private DemissaoRepository _demissaoRepository;

        public DemissaoAppService()
        {
            _context = new RecursosHumanosContext();
            _demissaoRepository = new DemissaoRepository(_context);
        }

        public IEnumerable<DemissaoViewModel> ObterTodasDemissoes()
        {
            var retorno = Mapper.Map<IEnumerable<DemissaoViewModel>>(_demissaoRepository.ObterTodos());
            return retorno;
        }

        public DemissaoViewModel ObterDemissaoPorIdProcesso(int idProcesso)
        {
            var retorno = Mapper.Map<DemissaoViewModel>(_demissaoRepository.ObterPrimeiroOuPadrao(x => x.IdProcesso == idProcesso));
            return retorno;
        }
    }
}
