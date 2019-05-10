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
                config.CreateMap<MSA, MSAModel>().ReverseMap();
                config.CreateMap<PoHeader, PoHeaderModel>().ReverseMap();
                config.CreateMap<SowHeader, SowHeaderModel>().ReverseMap();
            });
        }
    }
}