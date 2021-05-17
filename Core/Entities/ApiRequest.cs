using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Core.Entities
{
    public class ApiRequest
    {
        public string MonedaOrigenKey { get; set; }
        public string MonedaDestinoKey { get; set; }
        public double MontoAProcesar { get; set; }
    }
}
