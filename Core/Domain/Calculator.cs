using Remetee_Challenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Domain
{
    public class Calculator : ICalculator
    {
        private readonly ICurrencyClientService _currencyClientService;
        public Calculator(ICurrencyClientService currencyClientService) {
            _currencyClientService = currencyClientService;
        }
        public double MontoRequeridoParaLlegarAValorEsperado(string MonedaOrigenKey, string MonedaDestinoKey, double AmountToCalculated)
        {
            //Todo usar metodos de extencion 
            var UltimoRegistroObtenido =  _currencyClientService.GetCurrencyLayerResponse().Max(c => c.Id);
            var quoteOrigen = _currencyClientService.GetQuotes().Where(q => q.CurrencyLayerId == UltimoRegistroObtenido && q.Key == MonedaOrigenKey).FirstOrDefault();
            var quoteDestino = _currencyClientService.GetQuotes().Where(q => q.CurrencyLayerId == UltimoRegistroObtenido && q.Key == MonedaDestinoKey).FirstOrDefault();            

            var Fee = 0.03;

            return AmountToCalculated * (1 + Fee)/(quoteOrigen.valor * quoteDestino.valor);
        }

        public double ValorArecibirparaCubrirValorDestino(string MonedaOrigenKey, string MonedaDestinoKey, double AmountToCalculated)
        {
            var UltimoRegistroObtenido = _currencyClientService.GetCurrencyLayerResponse().Max(c => c.Id);
            var quoteOrigen = _currencyClientService.GetQuotes().Where(q => q.CurrencyLayerId == UltimoRegistroObtenido && q.Key == MonedaOrigenKey).FirstOrDefault();
            var quoteDestino = _currencyClientService.GetQuotes().Where(q => q.CurrencyLayerId == UltimoRegistroObtenido && q.Key == MonedaDestinoKey).FirstOrDefault();

            var Fee = 0.03;

            return AmountToCalculated * (1 - Fee) / (quoteOrigen.valor * quoteDestino.valor); 
        }
    }
}
