using AutoMapper;
using Estapar.CarStay.Data.Entity;
using Estapar.CarStay.Domain.Models;

namespace Estapar.CarStay.Domain.Profiles
{
    public class PassageProfile : Profile
    {
        public PassageProfile()
        {
            CreateMap<Passage, PassageDTO>()
                 .ForMember(dst => dst.Garagem, map => map.MapFrom(src => src.GarageCode))
                .ForMember(dst => dst.CarroPlaca, map => map.MapFrom(src => src.CarPlate))
                .ForMember(dst => dst.CarroMarca, map => map.MapFrom(src => src.CarBrand))
                .ForMember(dst => dst.CarroModelo, map => map.MapFrom(src => src.CarModel))
                .ForMember(dst => dst.DataHoraEntrada, map => map.MapFrom(src => src.StartDateTime))
                .ForMember(dst => dst.DataHoraSaida, map => map.MapFrom(src => src.EndDateTime))
                .ForMember(dst => dst.FormaPagamento, map => map.MapFrom(src => src.PaymentMethodCode))
                .ForMember(dst => dst.PrecoTotal, map => map.MapFrom(src => src.TotalPrice))
                .ReverseMap();

            CreateMap<PassageCreateDTO, Passage>()
                .ForMember(dst => dst.Code, map => map.MapFrom(src => Guid.NewGuid()))
                .ForMember(dst => dst.CreatedAt, map => map.MapFrom(src => DateTime.Now))
                .ForMember(dst => dst.GarageCode, map => map.MapFrom(src => src.Garagem))
                .ForMember(dst => dst.CarPlate, map => map.MapFrom(src => src.CarroPlaca))
                .ForMember(dst => dst.CarBrand, map => map.MapFrom(src => src.CarroMarca))
                .ForMember(dst => dst.CarModel, map => map.MapFrom(src => src.CarroModelo))
                .ForMember(dst => dst.StartDateTime, map => map.MapFrom(src => src.DataHoraEntrada))
                .ForMember(dst => dst.EndDateTime, map => map.MapFrom(src => src.DataHoraSaida))
                .ForMember(dst => dst.PaymentMethodCode, map => map.MapFrom(src => src.FormaPagamento));
        }
    }
}
