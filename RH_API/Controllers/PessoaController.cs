using RH_Application.AppServices;
using RH_Application.ViewModels;
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

        [AcceptVerbs("GET")]
        [Route("ObterFuncionariosAtivos")]
        public IEnumerable<PessoaRecrutamentoViewModel> ObterFuncionariosAtivos()
        {
            _pessoaCurriculoAppService = new PessoaCurriculoAppService();
            var retorno = _pessoaCurriculoAppService.ObterPessoasAtivas();

            return retorno;
        }

        [AcceptVerbs("GET")]
        [Route("ObterFuncionariosDemitidos")]
        public IEnumerable<PessoaDemissaoViewModel> ObterFuncionariosDemitidos()
        {
            _pessoaCurriculoAppService = new PessoaCurriculoAppService();
            var retorno = _pessoaCurriculoAppService.ObterPessoasDemitidas();

            return retorno;
        }
    }
}
