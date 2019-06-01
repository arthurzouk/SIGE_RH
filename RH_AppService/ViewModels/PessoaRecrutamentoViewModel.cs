namespace RH_Application.ViewModels
{
    public class PessoaRecrutamentoViewModel
    {
        public PessoaRecrutamentoViewModel()
        {
            PessoaCurriculo = new PessoaCurriculoViewModel();
            Recrutamento = new RecrutamentoViewModel();
        }

        public PessoaCurriculoViewModel PessoaCurriculo { get; set; }
        public RecrutamentoViewModel Recrutamento { get; set; }
    }
}
