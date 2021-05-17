using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Services
{
    public interface IConfigurationsService
    {
        //UNDONE Obtener configuracion de archivo o de la base de datos. Sacar Hardcodeo
        int CheckUpdateTime() => 1200000;
    }
}
