using AutoMapper;
using Remetee_Challenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Core.MapperProfiles
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CurrencyLayerDTO, CurrencyLayer>();
            CreateMap<Dictionary<string, double>, List<Quote>>();
            CreateMap<KeyValuePair<string, double>, Quote>()
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key.Substring(3,3)))
                .ForMember(dest => dest.valor, opt => opt.MapFrom(src => src.Value));


        }

    }


    
}
