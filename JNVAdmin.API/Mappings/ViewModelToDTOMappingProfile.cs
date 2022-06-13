using AutoMapper;
using JNVAdmin.API.ViewModels.Snack;
using JNVAdmin.Application.Dtos;

namespace JNVAdmin.API.Mappings
{
    public class ViewModelToDTOMappingProfile : Profile
    {
        public ViewModelToDTOMappingProfile()
        {
            CreateMap<SnackDTO, SnackCreate>().ReverseMap();
            CreateMap<SnackDTO, SnackUpdate>().ReverseMap();
        }
    }
}
