using Newtonsoft.Json;
using Remetee_Challenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Remetee_Challenge.Services
{
    public class CurrencyWebClienteService : ICurrencyWebClienteService
    {
        //TODO Pasar URL como parametro.
        private const string BaseUrl = "http://apilayer.net/api/live?access_key=4c69d262c761102d6c662dc90286ad02&source=USD&format=1";
        public async Task<CurrencyLayerDTO> ObtenerValoresCurrencyServerAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.GetAsync(BaseUrl);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Erro al obtener los datos");
                }

                var content = await httpResponse.Content.ReadAsStringAsync();
                                
                var tasks = JsonConvert.DeserializeObject<CurrencyLayerDTO>(content);

                return tasks;
            }
        }
    }
}
