using Remetee_Challenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Commands.Interfaces
{
   public interface IRequesProcessor
    {
        ApiResponse ProcesRequestGetValorRequeridoParaAlcanzarValorEsperado(ApiRequest request);
        ApiResponse ProcesRequestGetMontoRequeridoParaLlegarAValorEsperado(ApiRequest request);

    }
}
