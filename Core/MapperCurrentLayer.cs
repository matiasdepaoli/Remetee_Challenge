using AutoMapper;
using Remetee_Challenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Core
{
    public class MapperCurrentLayer
    {
        private readonly IMapper _Mapper;

        public MapperCurrentLayer(IMapper mapper)
        {
            _Mapper = mapper;
        }
        public  CurrencyLayer  Convertir(CurrencyLayerDTO currency)
        {
            var mapped = _Mapper.Map<CurrencyLayer>(currency); ;
            
            return mapped; 
        }
    }
}
