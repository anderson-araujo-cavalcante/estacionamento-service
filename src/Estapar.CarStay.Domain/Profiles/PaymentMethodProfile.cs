using AutoMapper;
using Estapar.CarStay.Data.Entity;
using Estapar.CarStay.Domain.Models;

namespace Estapar.CarStay.Domain.Profiles
{
    public class PaymentMethodProfile : Profile
    {
        public PaymentMethodProfile()
        {
            CreateMap<PaymentMethod, PaymentMethodDTO>()
                .ForMember(dst => dst.Codigo, map => map.MapFrom(src => src.Code))
                .ForMember(dst => dst.Descricao, map => map.MapFrom(src => src.Description))
                .ReverseMap();
        }
    }
}
