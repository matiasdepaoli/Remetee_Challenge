using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Services
{
    public interface IConfigurationsService
    {
        int CheckUpdateTime();
        double fee();
    }
}
