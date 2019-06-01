namespace RH_Application.ViewModels
{
    public class PessoaDemissaoRecrutViewModel
    {
        public PessoaDemissaoRecrutViewModel()
        {
            PessoaCurriculo = new PessoaCurriculoViewModel();
            Demissao = new DemissaoViewModel();
            Recrutamento = new RecrutamentoViewModel();
        }

        public PessoaCurriculoViewModel PessoaCurriculo { get; set; }
        public DemissaoViewModel Demissao { get; set; }
        public RecrutamentoViewModel Recrutamento { get; set; }
    }
}
