using System;

namespace RH_Dominio.Models
{
    public class Demissao : Entity
    {
        public int IdProcesso { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string SetorSolicitante { get; set; }
        public string Responsavel { get; set; }
        public int QuantidadeDeFalhas { get; set; }
        public string Motivo { get; set; }
        public bool FalhaGrave { get; set; }

        public string IdFuncionario { get; set; }
        public virtual PessoaCurriculo Funcionario { get; set; }
    }
}
