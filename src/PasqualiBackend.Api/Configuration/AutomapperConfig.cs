using AutoMapper;
using PasqualiBackend.Api.ViewModels;
using PasqualiBackend.Business.Models;

namespace PasqualiBackend.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<UsuarioViewModel, Usuario>().ReverseMap();
            CreateMap<UsuarioAddViewModel, Usuario>().ReverseMap();
        }
    }
}
