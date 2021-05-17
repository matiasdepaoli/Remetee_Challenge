﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Remetee_Challenge.Core;
using Remetee_Challenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Remetee_Challenge.Commands
{
    public class BackgroundExchangeRateClient : BackgroundService ,IHostedService
    {
        private readonly ICurrencyWebClienteService _CurrencyWebClienteService;
        private readonly ICurrencyClientService _CurrencyClientService;
      //  private readonly ILogger _logger;
        private readonly IConfigurationsService _Configuration;
        private readonly MapperCurrentLayer _MapperCurrentLayer;


        public BackgroundExchangeRateClient( IServiceScopeFactory factory) 
        {

            _CurrencyWebClienteService = factory.CreateScope().ServiceProvider.GetRequiredService<ICurrencyWebClienteService>();
            _CurrencyClientService = factory.CreateScope().ServiceProvider.GetRequiredService<ICurrencyClientService>();
            _Configuration =  factory.CreateScope().ServiceProvider.GetRequiredService<IConfigurationsService>();
            _MapperCurrentLayer = factory.CreateScope().ServiceProvider.GetRequiredService<MapperCurrentLayer>();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
               // _logger.LogDebug($"GracePeriod task doing background work.");


                var client = await _CurrencyWebClienteService.ObtenerValoresCurrencyServerAsync();
                var currenc = _MapperCurrentLayer.Convertir(client);
                _CurrencyClientService.AddCurrencyLayerResponse(currenc);
                await Task.Delay(_Configuration.CheckUpdateTime(), stoppingToken);

            }
          
        }
    }
}
