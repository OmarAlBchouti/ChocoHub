using AutoMapper;
using ChocolateFactoryManagement.Domain.DTOs;
using ChocolateFactoryManagement.Domain.Models;

namespace ChocolateFactoryManagement.Domain.AutoMapper
{
    public static class AutoMapperClasses
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<ChocolateBar, ChocolateBarDto>().ReverseMap();
                CreateMap<Factory, FactoryDto>().ReverseMap();
                CreateMap<WholesalerStock, WholesalerStockDto>().ReverseMap();
                CreateMap<RequestDto, QuoteSummaryDto>()
                    .ForMember(dest => dest.OrderSummary, opt => opt.MapFrom(src => src.ChocolateBars))
                    .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => "0"))
                    .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => 0))
                    .ReverseMap();
            }
        }
    }
}
