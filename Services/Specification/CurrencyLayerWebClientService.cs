using Microsoft.EntityFrameworkCore;
using Remetee_Challenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Services
{
    public class CurrencyLayerWebClientService: DbContext, ICurrencyClientService
    {        
        public DbSet<CurrencyLayer> CurrencyLayerResponse { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        public CurrencyLayerWebClientService(DbContextOptions<CurrencyLayerWebClientService> options) : base(options)
        { }
                
        public void AddCurrencyLayerResponse(CurrencyLayer currencyLayerResponse)
        {
                CurrencyLayerResponse.Add(currencyLayerResponse);
                this.SaveChanges();
                return;
        }
        public List<CurrencyLayer> GetCurrencyLayerResponse() =>  CurrencyLayerResponse.ToList();
        public CurrencyLayer GetCurrencyLayerResponse(long Id)
        {
            return CurrencyLayerResponse.Where(c => c.Id == Id).FirstOrDefault();
        }

        public  void  AddQuote(Quote quote)
        {
            Quotes.Add(quote);
            this.SaveChanges();
            return;
        }
        public  List<Quote> GetQuotes() => Quotes.ToList();
        public  Quote GetQuote(long Id)
        {
            return Quotes.Where(c => c.Id == Id).FirstOrDefault();
        }



    }

}
