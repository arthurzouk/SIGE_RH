using System;
using System.Collections.Generic;

namespace RH_Dominio.Models
{
    public class PessoaCurriculo : Entity
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Escolaridade { get; set; }
        public string Curso { get; set; }

        public virtual ICollection<Demissao> Demissoes { get; set; }
        public virtual ICollection<Recrutamento> Recrutamentos { get; set; }
        public virtual ICollection<Recrutamento> RecrutamentosAprovados { get; set; }
    }
}
