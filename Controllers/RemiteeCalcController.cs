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
        private readonly IRequesProcessor _RequesProcessor;

        public RemiteeCalcController(IRequesProcessor requesProcessor)
        {

            _RequesProcessor = requesProcessor;
        }
        // GET: api/<RemiteeCalcController>

        [Route("ValorRequeridoParaAlcanzarUnMontoDeceado")]
        [HttpGet]
        public IActionResult GetValorRequeridoParaAlcanzarValorEsperado([FromQuery] ApiRequest request)
        {
            var ApiResponse = _RequesProcessor.ProcesRequestGetValorRequeridoParaAlcanzarValorEsperado(request);
            if (ApiResponse.Success)
            return Ok(ApiResponse);

            return BadRequest(ApiResponse);
        }

        [Route("ValorResultanteAplicandoComisiones")]
        [HttpGet]
        public IActionResult GetMontoRequeridoParaLlegarAValorEsperado([FromQuery] ApiRequest request)
        {
            var ApiResponse = _RequesProcessor.ProcesRequestGetMontoRequeridoParaLlegarAValorEsperado(request);
            if (ApiResponse.Success)
                return Ok(ApiResponse);

            return BadRequest(ApiResponse);
        }
    }
}
