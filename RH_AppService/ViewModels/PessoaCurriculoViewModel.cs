using System;

namespace RH_AppService.ViewModels
{
    public class PessoaCurriculoViewModel
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Escolaridade { get; set; }
        public string Curso { get; set; }
        public decimal Salario { get; set; }
    }
}
