using RH_Application.AppServices;
using RH_Application.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace RH_API.Controllers
{
    [RoutePrefix("API/Recrutamento")]
    public class RecrutamentoController : ApiController
    {
        private RecrutamentoAppService _recrutamentoAppService;
        private PessoaCurriculoAppService _pessoaCurriculoAppService;

        [AcceptVerbs("GET")]
        [Route("ObterProcessosRecrutamento")]
        public IEnumerable<RecrutamentoViewModel> ObterProcessosRecrutamento()
        {
            _recrutamentoAppService = new RecrutamentoAppService();
            var retorno = _recrutamentoAppService.ObterTodosRecrutamentos();

            return retorno;
        }

        [AcceptVerbs("GET")]
        [Route("ObterProcessoRecrutamentoPorProcessoId")]
        public RecrutamentoViewModel ObterProcessoRecrutamentoPorProcessoId(int processo_id)
        {
            _recrutamentoAppService = new RecrutamentoAppService();
            var retorno = _recrutamentoAppService.ObterRecrutamentoPorIdProcesso(processo_id);

            return retorno;
        }

        [AcceptVerbs("GET")]
        [Route("ObterCurriculoPorProcesso")]
        public PessoaRecrutamentoViewModel ObterCurriculoPorProcesso(int processo_id)
        {
            _pessoaCurriculoAppService = new PessoaCurriculoAppService();
            var retorno = _pessoaCurriculoAppService.ObterCurriculoPorIdProcessoDoRecrutamento(processo_id);

            return retorno;
        }

        [AcceptVerbs("GET")]
        [Route("ObterCurriculosAprovados")]
        public IEnumerable<PessoaRecrutamentoViewModel> ObterCurriculosAprovados()
        {
            _recrutamentoAppService = new RecrutamentoAppService();
            _pessoaCurriculoAppService = new PessoaCurriculoAppService();
            var retorno = new List<PessoaRecrutamentoViewModel>();

            var todosRecrutamentos = _recrutamentoAppService.ObterTodosRecrutamentos();
            foreach(var i in todosRecrutamentos)
            {
                var curriculo = _pessoaCurriculoAppService.ObterCurriculoPorIdProcessoDoRecrutamento(i.IdProcesso);
                if (curriculo.Recrutamento.Aprovado) retorno.Add(curriculo);
            }

            return retorno;
        }
    }
}
