using RH_Application.AppServices;
using RH_AppService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RH_API.Controllers
{
    public class FuncionarioController : ApiController
    {
        private PessoaCurriculoAppService _pessoaCurriculoAppService;

        [HttpGet]
        public IEnumerable<PessoaCurriculoViewModel> ObterTodosCurriculos()
        {
            _pessoaCurriculoAppService = new PessoaCurriculoAppService();
            var retorno = _pessoaCurriculoAppService.ObterTodosCurriculos();

            return retorno;
        }
    }
}
