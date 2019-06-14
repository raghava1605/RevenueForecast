using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RevenueForecast.Common.Models;
using RevenueForecast.Common.Data;

namespace RevenueForecast.API.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Customer, CustomerModel>().ReverseMap();
                config.CreateMap<MSA, MSAModel>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.CustomerName))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Customer.Owner))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Customer.Description))
                .ReverseMap();
                config.CreateMap<PoHeader, PoHeaderModel>().ReverseMap();
                config.CreateMap<SowHeader, SowHeaderModel>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.CustomerName))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Customer.Owner))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Customer.Description))
                .ReverseMap();
                config.CreateMap<SowDetail, SowDetailModel>().ReverseMap();
                config.CreateMap<PoDetail, PoDetailsModel>().ReverseMap(); 
                config.CreateMap<SowDetailActual, SowDetailActualModel>().ReverseMap().ForMember(x => x.TotalAmount, opt => opt.Ignore());
                config.CreateMap<Employee, EmployeeModel>().ReverseMap();
                config.CreateMap<EmployeeRole, EmployeeRolesModel>().ReverseMap();
                config.CreateMap<Location, LocationModel>().ReverseMap();
            });
        }
    }
}