using AutoMapper;
using JNVAdmin.Application.Dtos;
using JNVAdmin.Domain.Entities;

namespace JNVAdmin.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Snack, SnackDTO>().ReverseMap();
            CreateMap<Schedule, ScheduleDTO>().ReverseMap();
        }
    }
}
