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
           // CreateMap<CurrencyLayer, CurrencyLayerDTO>();//.ForMember(dest => dest.quotes, opt => opt.MapFrom(src => src.quotes));
            CreateMap<Dictionary<string, double>, List<Quote>>();//.ConvertUsing(m=> { return m.Select(p => new Quote { Key = p.Key.Substring(3, 3), valor = p.Value }).ToList(); });
          //  CreateMap<List<Quote>, Dictionary<string, double>>();
            CreateMap<CurrencyLayerDTO, CurrencyLayer>();
            CreateMap<KeyValuePair<string, double>, Quote>()
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.valor, opt => opt.MapFrom(src => src.Value));


        }

    }

    //internal class DicToListConverter : ITypeConverter<Dictionary<string, double>, List<Quote>>
    //{
    //    public List<Quote> Convert(Dictionary<string, double> source, List<Quote> destination, ResolutionContext context)
    //    {
    //        return source.Select(p => new Quote { Key = p.Key.Substring(3, 3), valor = p.Value }).ToList();
    //    }
    //}

    
}
/*
 
             //var config = new MapperConfiguration(cfg =>  cfg.CreateMap<CurrencyLayerDTO, CurrencyLayer>()
            //.ForMember(dest => dest.source, opt => opt.MapFrom(src => src.source))
            //);

            //config.AssertConfigurationIsValid();
            //var mapper = config.CreateMapper();

            //CurrencyLayer currencyLayer = mapper.Map<CurrencyLayerDTO, CurrencyLayer>(currency);
             
            return new CurrencyLayer {source =currency.source,
                                      privacy = currency.privacy,
                                      quotes = currency.quotes.Select(p => new Quote { Key = p.Key.Substring(currency.source.Length, currency.source.Length), valor = p.Value }).ToList(),
                                      terms = currency.terms,
                                      timestamp = currency.timestamp,
                                      success  = currency.success };
 
 */