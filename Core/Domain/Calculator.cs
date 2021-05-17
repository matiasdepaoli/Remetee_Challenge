using Remetee_Challenge.Core.Entities;
using Remetee_Challenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Domain
{
    public class Calculator : ICalculator
    {
        private readonly ICurrencyClientService _CurrencyClientService;
        private readonly IConfigurationsService _ConfigurationsService;

        private delegate double Del(double AmountToCalculated, double Fee, Quote quoteOrigen, Quote quoteDestino);
        public Calculator(ICurrencyClientService currencyClientService, IConfigurationsService configurationsService) {
            _CurrencyClientService = currencyClientService;
            _ConfigurationsService = configurationsService;
        }
        public double MontoRequeridoParaLlegarAValorEsperado(string MonedaOrigenKey, string MonedaDestinoKey, double AmountToCalculated)
        {
            return ReaplizarOperacion(MonedaOrigenKey, MonedaDestinoKey, AmountToCalculated, calculoMontoRequeridoParaLlegarAValorEsperado);
        }

        public double ValorARecibirParaCubrirValorDestino(string MonedaOrigenKey, string MonedaDestinoKey, double AmountToCalculated)
        {
            return ReaplizarOperacion(MonedaOrigenKey, MonedaDestinoKey, AmountToCalculated, CalculoValorARecibirParaCubrirValorDestino);
        }

        private double ReaplizarOperacion(string MonedaOrigenKey, string MonedaDestinoKey, double AmountToCalculated, Del Calculador)
        {
            var UltimoRegistroObtenido = _CurrencyClientService.GetCurrencyLayerResponse().Max(c => c.Id);
            var quoteOrigen = _CurrencyClientService.GetQuotes().Where(q => q.CurrencyLayerId == UltimoRegistroObtenido && q.Key == MonedaOrigenKey).FirstOrDefault();
            var quoteDestino = _CurrencyClientService.GetQuotes().Where(q => q.CurrencyLayerId == UltimoRegistroObtenido && q.Key == MonedaDestinoKey).FirstOrDefault();
            
            var Fee = _ConfigurationsService.fee();
            return Calculador(AmountToCalculated, Fee, quoteOrigen, quoteDestino);
            
        }
        private double calculoMontoRequeridoParaLlegarAValorEsperado(double AmountToCalculated, double Fee, Quote quoteOrigen, Quote quoteDestino)
        {
            return AmountToCalculated * (1 + Fee) / (quoteOrigen.valor * quoteDestino.valor);
        }

        private double CalculoValorARecibirParaCubrirValorDestino(double AmountToCalculated, double Fee, Quote quoteOrigen, Quote quoteDestino)
        {
            return AmountToCalculated * (1 - Fee) / (quoteOrigen.valor * quoteDestino.valor); 
        }
    }
}
