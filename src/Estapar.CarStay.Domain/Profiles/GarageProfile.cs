using AutoMapper;
using Estapar.CarStay.Data.Entity;
using Estapar.CarStay.Domain.Models;

namespace Estapar.CarStay.Domain.Profiles
{
    public class GarageProfile : Profile
    {
        public GarageProfile()
        {
            CreateMap<Garage, GarageDTO>()
                 .ForMember(dst => dst.Codigo, map => map.MapFrom(src => src.Code))
                .ForMember(dst => dst.Nome, map => map.MapFrom(src => src.Name))
                .ForMember(dst => dst.Preco_1aHora, map => map.MapFrom(src => src.Price_1aHour))
                .ForMember(dst => dst.Preco_Mensalista, map => map.MapFrom(src => src.Price_Monthly))
                .ForMember(dst => dst.Preco_HorasExtra, map => map.MapFrom(src => src.Price_ExtraHours))
                .ReverseMap();
        }
    }
}
