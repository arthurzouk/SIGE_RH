using AutoMapper;
using RH_AppService.ViewModels;
using RH_Banco.Context;
using RH_Banco.Repository;
using System.Collections.Generic;

namespace RH_Application.AppServices
{
    public class RecrutamentoAppService
    {
        private RecursosHumanosContext _context;
        private RecrutamentoRepository _recrutamentoRepository;

        public RecrutamentoAppService()
        {
            _context = new RecursosHumanosContext();
            _recrutamentoRepository = new RecrutamentoRepository(_context);
        }

        public IEnumerable<RecrutamentoViewModel> ObterTodosRecrutamentos()
        {
            var retorno = Mapper.Map<IEnumerable<RecrutamentoViewModel>>(_recrutamentoRepository.ObterTodos());
            return retorno;
        }

        public RecrutamentoViewModel ObterRecrutamentoPorIdProcesso(int idProcesso)
        {
            var retorno = Mapper.Map<RecrutamentoViewModel>(_recrutamentoRepository.ObterPrimeiroOuPadrao(x => x.IdProcesso == idProcesso));
            return retorno;
        }
    }
}
