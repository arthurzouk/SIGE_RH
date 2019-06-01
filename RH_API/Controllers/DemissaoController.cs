using RH_Application.AppServices;
using RH_AppService.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace RH_API.Controllers
{
    [RoutePrefix("API/Demissao")]
    public class DemissaoController : ApiController
    {
        private DemissaoAppService _demissaoAppService;

        [AcceptVerbs("GET")]
        [Route("ObterProcessosDemissao")]
        public IEnumerable<DemissaoViewModel> ObterProcessosDemissao()
        {
            _demissaoAppService = new DemissaoAppService();
            var retorno = _demissaoAppService.ObterTodasDemissoes();

            return retorno;
        }

        [AcceptVerbs("GET")]
        [Route("ObterProcessoDemissaoPorProcessoId")]
        public DemissaoViewModel ObterProcessoDemissaoPorProcessoId(int processo_id)
        {
            _demissaoAppService = new DemissaoAppService();
            var retorno = _demissaoAppService.ObterDemissaoPorIdProcesso(processo_id);

            return retorno;
        }
    }
}
