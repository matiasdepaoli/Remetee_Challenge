using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Core.Entities
{
    public class ApiResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public double Data { get; set; }
    }
}
