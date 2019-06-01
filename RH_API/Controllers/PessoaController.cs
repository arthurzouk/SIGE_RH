using RH_Application.AppServices;
using RH_AppService.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace RH_API.Controllers
{
    [RoutePrefix("API/Pessoa")]
    public class PessoaController : ApiController
    {
        private PessoaCurriculoAppService _pessoaCurriculoAppService;

        [AcceptVerbs("GET")]
        [Route("ObterTodosCurriculos")]
        public IEnumerable<PessoaCurriculoViewModel> ObterTodosCurriculos()
        {
            _pessoaCurriculoAppService = new PessoaCurriculoAppService();
            var retorno = _pessoaCurriculoAppService.ObterTodosCurriculos();

            return retorno;
        }

        [AcceptVerbs("GET")]
        [Route("ObterPorCpf")]
        public PessoaCurriculoViewModel ObterPorCpf(string cpf)
        {
            _pessoaCurriculoAppService = new PessoaCurriculoAppService();
            var retorno = _pessoaCurriculoAppService.ObterCurriculoPorCpf(cpf);

            return retorno;
        }
    }
}
