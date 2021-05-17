using FluentValidation;
using Remetee_Challenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Core.Validators
{
    public class ApiRequestValidator:AbstractValidator<ApiRequest>
    {

        public ApiRequestValidator() {

            RuleFor(p => p.MonedaOrigenKey).NotEmpty().WithMessage("TipomMoneda origen debe tener valor");
            RuleFor(p => p.MonedaOrigenKey).Length(3, 3).WithMessage("Formato de moneda incorrecto");

            RuleFor(p => p.MonedaDestinoKey).NotEmpty().WithMessage("Tipo moneda destino debe tener valor");
            RuleFor(p => p.MonedaDestinoKey).Length(3, 3).WithMessage("Formato de moneda incorrecto");


            
            RuleFor(p => p.MontoAProcesar).NotNull().WithMessage("Tipo moneda destino debe tener valor");
            RuleFor(p => p.MontoAProcesar).GreaterThan(0).WithMessage("El monto a convertir dede ser mayor que cero");



        }
        

    }
}
