using AutoMapper;
using TestApp.Entitys;
using TestApp.Entitys.Dtos;

namespace TestApp.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<History, HistoryDto>().ReverseMap();
            CreateMap<History, HistoryCreateDto>().ReverseMap();
        }
    }
}
