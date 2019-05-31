﻿using RH_Application.AppServices;
using RH_AppService.ViewModels;
using System.Web.Http;

namespace RH_API.Controllers
{
    public class RecrutamentoController : ApiController
    {
        private PessoaCurriculoAppService _pessoaCurriculoAppService;

        [HttpGet]
        public PessoaCurriculoViewModel ObterCurriculoPorProcesso(int processo_id)
        {
            _pessoaCurriculoAppService = new PessoaCurriculoAppService();
            var retorno = _pessoaCurriculoAppService.ObterCurriculoPorIdProcessoDoRecrutamento(processo_id);

            return retorno;
        }
    }
}
