using Remetee_Challenge.Commands.Interfaces;
using Remetee_Challenge.Core.Domain;
using Remetee_Challenge.Core.Entities;
using Remetee_Challenge.Core.Validators;
using Remetee_Challenge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Commands
{
    public class RequesProcessor : IRequesProcessor
    {
        private readonly ICalculator _Calculator;
        private readonly ApiRequestValidator _Validator;

        private delegate double Del(string MonedaOrigenKey, string MonedaDestinoKey, double AmountToCalculated);
        public RequesProcessor(ApiRequestValidator validator, ICalculator calculator) {
            _Calculator = calculator;
            _Validator = validator;
        }

        private  ApiResponse ProcessRequest(ApiRequest request, Del callback) {

            var outputValue = 0.0;
            var DigestOfValidation = _Validator.Validate(request);
           

            if (!DigestOfValidation.IsValid)
            {
                var Messages = String.Join(", ", DigestOfValidation.Errors.Select(a => a.ErrorMessage).ToList());
                
                return ApiResponseFactory.GetApiRequest(false, outputValue, Messages);
            }
            var OutPutProcess = ApiResponseFactory.GetApiRequest(true, outputValue, "");
            try {
                OutPutProcess.Data = callback(request.MonedaOrigenKey, request.MonedaOrigenKey, request.MontoAProcesar);
            }
            catch (Exception FalloEnCalculo){
                OutPutProcess.Data = 0;
                OutPutProcess.Success = false;
                OutPutProcess.Message= "Error en los datos recibidos"; 
            }

            
            return OutPutProcess;
        }

        public ApiResponse ProcesRequestGetMontoRequeridoParaLlegarAValorEsperado(ApiRequest request)
        {
            return ProcessRequest(request, _Calculator.MontoRequeridoParaLlegarAValorEsperado);
        }

        public ApiResponse ProcesRequestGetValorRequeridoParaAlcanzarValorEsperado(ApiRequest request)
        {
            return ProcessRequest(request, _Calculator.ValorARecibirParaCubrirValorDestino);
        }
    }
}
