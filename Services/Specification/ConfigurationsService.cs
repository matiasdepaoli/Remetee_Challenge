using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Services
{
    public class ConfigurationsService : IConfigurationsService
    {
        public int feeOperation { private get; set; }
        public int UpdateTime { private get; set; }


        public int CheckUpdateTime()
        {
            return 120000;
        }

        public double fee()
        {
            return 0.03;
        }
    }
}
