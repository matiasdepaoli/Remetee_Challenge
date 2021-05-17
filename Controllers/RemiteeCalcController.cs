using Microsoft.AspNetCore.Mvc;
using Remetee_Challenge.Commands.Interfaces;
using Remetee_Challenge.Core;
using Remetee_Challenge.Core.Entities;
using Remetee_Challenge.Domain;
using Remetee_Challenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Remetee_Challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RemiteeCalcController : ControllerBase
    {
        private readonly IRequesProcessor _RequesProcesspr;

        public RemiteeCalcController(IRequesProcessor requesProcesspr)
        {

            _RequesProcesspr = requesProcesspr;
        }
        // GET: api/<RemiteeCalcController>
        
        [HttpGet]
        public IActionResult GetValorRequeridoParaAlcanzarValorEsperado([FromQuery] ApiRequest request)
        {
            var ApiResponse = _RequesProcesspr.ProcesRequestGetValorRequeridoParaAlcanzarValorEsperado(request);
            if (ApiResponse.Success)
            return Ok(ApiResponse);

            return BadRequest(ApiResponse);
        }

        //[HttpGet ("{MonedaOrigenKey, ValorRecibido, MonedaDestinoKey }")]
        //public IActionResult GetMontoARecibirparaCubrirValorDestino(string MonedaOrigenKey, double ValorRecibido,string MonedaDestinoKey)
        //{
        //    return Ok(_Calculator.ValorArecibirparaCubrirValorDestino(MonedaOrigenKey, ValorRecibido, MonedaDestinoKey));
        //}

    }
}
