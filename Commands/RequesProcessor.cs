using Remetee_Challenge.Commands.Interfaces;
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
            var DigestOfValidation = _Validator.Validate(request);
            //TODOcrer factoria para objeto response.
            if (!DigestOfValidation.IsValid)
            {
                var Messages = String.Join(", ", DigestOfValidation.Errors.Select(a => a.ErrorMessage).ToList());
                return new ApiResponse { Success = false, Message = Messages };
            }
            var outputValue = 0.0;

            outputValue = callback(request.MonedaOrigenKey, request.MonedaOrigenKey, request.MontoAProcesar);

            return new ApiResponse { Success = true, Data = outputValue };
        }

        public ApiResponse ProcesRequestGetMontoRequeridoParaLlegarAValorEsperado(ApiRequest request)
        {
            return ProcessRequest(request, _Calculator.MontoRequeridoParaLlegarAValorEsperado);
        }

        public ApiResponse ProcesRequestGetValorRequeridoParaAlcanzarValorEsperado(ApiRequest request)
        {
            return ProcessRequest(request, _Calculator.ValorArecibirparaCubrirValorDestino);
        }
    }
}
