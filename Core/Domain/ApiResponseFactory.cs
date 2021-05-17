using Remetee_Challenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Core.Domain
{
    public class ApiResponseFactory
    {
        public static ApiResponse GetApiRequest(bool Success, double Data, string Message)
        { 
            return new ApiResponse { Success = Success, Data = Data,Message = Message };
        }


    }
}
