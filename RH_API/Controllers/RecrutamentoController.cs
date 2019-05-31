using RH_Banco.Context;
using RH_Banco.Repository;
using RH_Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RH_API.Controllers
{
    public class RecrutamentoController : ApiController
    {
        public RecrutamentoController()
        {

        }

        [HttpGet]
        public IEnumerable<PessoaCurriculo> ObterCurriculosDasPessoas()
        {
            RecursosHumanosContext context = new RecursosHumanosContext();
            PessoaCurriculoRepository pessoaCurriculoRepository = new PessoaCurriculoRepository(context);
            return pessoaCurriculoRepository.ObterTodos();
        }
    }
}
