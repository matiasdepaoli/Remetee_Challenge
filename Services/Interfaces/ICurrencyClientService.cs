using Remetee_Challenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Services
{
    public interface ICurrencyClientService
    {
        void AddCurrencyLayerResponse(CurrencyLayer currencyLayer);
        CurrencyLayer GetCurrencyLayerResponse(long id);
        List<CurrencyLayer> GetCurrencyLayerResponse();
        
        void AddQuote(Quote quote);
        List<Quote> GetQuotes();
        Quote GetQuote(long id);

    }
}
