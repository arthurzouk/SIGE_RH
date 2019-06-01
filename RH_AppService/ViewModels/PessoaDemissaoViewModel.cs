namespace RH_Application.ViewModels
{
    public class PessoaDemissaoViewModel
    {
        public PessoaDemissaoViewModel()
        {
            PessoaCurriculo = new PessoaCurriculoViewModel();
            Demissao = new DemissaoViewModel();
        }

        public PessoaCurriculoViewModel PessoaCurriculo { get; set; }
        public DemissaoViewModel Demissao { get; set; }
    }
}
