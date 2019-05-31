using System;

namespace RH_AppService.ViewModels
{
    public class RecrutamentoViewModel
    {
        public int IdProcesso { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFechamento { get; set; }
        public string SetorSolicitante { get; set; }
        public string Responsavel { get; set; }
        public string Situacao { get; set; }
        public string PerfilVaga { get; set; }
        public string TestesAAplicar { get; set; }
        public string Entrevistador { get; set; }
        public bool Aprovado { get; set; }
        public string Observacoes { get; set; }

        public string PessoaCurriculoId { get; set; }
    }
}
