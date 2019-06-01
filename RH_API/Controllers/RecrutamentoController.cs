using RH_Application.AppServices;
using RH_AppService.ViewModels;
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
        public PessoaCurriculoViewModel ObterCurriculoPorProcesso(int processo_id)
        {
            _pessoaCurriculoAppService = new PessoaCurriculoAppService();
            var retorno = _pessoaCurriculoAppService.ObterCurriculoPorIdProcessoDoRecrutamento(processo_id);

            return retorno;
        }
    }
}
