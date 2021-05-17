using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Domain
{
    public interface ICalculator
    {
        double MontoRequeridoParaLlegarAValorEsperado(string MonedaOrigenKey, string MonedaDestinoKey, double AmountToCalculated);
        double ValorArecibirparaCubrirValorDestino(string MonedaOrigenKey, string MonedaDestinoKey, double AmountToCalculated);
    }
}
