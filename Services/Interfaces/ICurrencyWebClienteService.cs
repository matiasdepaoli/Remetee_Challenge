using Remetee_Challenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Services
{
   public  interface ICurrencyWebClienteService
    {
        Task<CurrencyLayerDTO> ObtenerValoresCurrencyServerAsync();
    }
}
