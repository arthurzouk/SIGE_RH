using AutoMapper;
using RH_Application.ViewModels;
using RH_Dominio.Models;

namespace RH_Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<PessoaCurriculo, PessoaCurriculoViewModel>().ReverseMap();
            Mapper.CreateMap<Recrutamento, RecrutamentoViewModel>().ReverseMap();
            Mapper.CreateMap<Demissao, DemissaoViewModel>().ReverseMap();
        }
    }
}
