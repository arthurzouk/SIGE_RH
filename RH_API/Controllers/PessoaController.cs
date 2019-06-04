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
        [Route("ObterFuncionariosArea")]
        public IEnumerable<FuncionarioViewModel> ObterFuncionariosArea()
        {
            _pessoaCurriculoAppService = new PessoaCurriculoAppService();
            var pessoasRecrutamento = _pessoaCurriculoAppService.ObterPessoasAtivas();
            var retorno = new List<FuncionarioViewModel>();
            foreach (var pessoaRecrut in pessoasRecrutamento)
            {
                retorno.Add(new FuncionarioViewModel
                {
                    Id = pessoaRecrut.PessoaCurriculo.Id,
                    CPF = pessoaRecrut.PessoaCurriculo.CPF,
                    Nome = pessoaRecrut.PessoaCurriculo.Nome,
                    DataNascimento = pessoaRecrut.PessoaCurriculo.DataNascimento,
                    Endereco = pessoaRecrut.PessoaCurriculo.Endereco,
                    Escolaridade = pessoaRecrut.PessoaCurriculo.Escolaridade,
                    Curso = pessoaRecrut.PessoaCurriculo.Curso,
                    AreaFuncional = pessoaRecrut.Recrutamento.SetorSolicitante
                });
            }

            return retorno;
        }

        [AcceptVerbs("GET")]
        [Route("ObterFuncionariosSalarioArea")]
        public IEnumerable<FuncionarioSalarioViewModel> ObterFuncionariosSalarioArea()
        {
            _pessoaCurriculoAppService = new PessoaCurriculoAppService();
            var pessoasRecrutamento = _pessoaCurriculoAppService.ObterPessoasAtivas();
            var retorno = new List<FuncionarioSalarioViewModel>();
            foreach (var pessoaRecrut in pessoasRecrutamento)
            {
                retorno.Add(new FuncionarioSalarioViewModel
                {
                    Id = pessoaRecrut.PessoaCurriculo.Id,
                    CPF = pessoaRecrut.PessoaCurriculo.CPF,
                    Nome = pessoaRecrut.PessoaCurriculo.Nome,
                    DataNascimento = pessoaRecrut.PessoaCurriculo.DataNascimento,
                    Endereco = pessoaRecrut.PessoaCurriculo.Endereco,
                    Escolaridade = pessoaRecrut.PessoaCurriculo.Escolaridade,
                    Curso = pessoaRecrut.PessoaCurriculo.Curso,
                    Salario = pessoaRecrut.PessoaCurriculo.Salario,
                    AreaFuncional = pessoaRecrut.Recrutamento.SetorSolicitante
                });
            }

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

        [AcceptVerbs("GET")]
        [Route("ReceberReclamacao")]
        public FuncionarioReclamacaoViewModel ReceberReclamacao(string reclamacao)
        {
            _pessoaCurriculoAppService = new PessoaCurriculoAppService();

            var retorno = _pessoaCurriculoAppService.ObterFuncionarioReclamacao(reclamacao);

            return retorno;
        }

        [AcceptVerbs("GET")]
        [Route("ObterFuncionariosEnvolvidosOperacaoEstoque")]
        public IEnumerable<FuncionarioSalarioViewModel> ObterFuncionariosEnvolvidosOperacaoEstoque()
        {
            _pessoaCurriculoAppService = new PessoaCurriculoAppService();

            var retorno = _pessoaCurriculoAppService.ObterFuncionariosPorSetor("Produção");

            return retorno;
        }

        [AcceptVerbs("GET")]
        [Route("ObterCustoDoRecursoPorCampanha")]
        public FuncionarioCampanhaViewModel ObterCustoDoRecursoPorCampanha(string campanha)
        {
            _pessoaCurriculoAppService = new PessoaCurriculoAppService();

            var retorno = _pessoaCurriculoAppService.ObterCustoDoRecursoPorCampanha(campanha);

            return retorno;
        }
    }
}
