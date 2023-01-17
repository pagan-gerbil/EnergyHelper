using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EnergyHelper.OctopusAgile
{
    internal class OctopusAgileApi
    {
        //https://api.octopus.energy/v1/products/AGILE-FLEX-22-11-25/electricity-tariffs/E-1R-AGILE-FLEX-22-11-25-C/standard-unit-rates/

        public async Task<StandardUnitRatesReponse> GetStandardUnitRates()
        {
            var request = new HttpClient();
            var uri = new Uri("https://api.octopus.energy/v1/products/AGILE-FLEX-22-11-25/electricity-tariffs/E-1R-AGILE-FLEX-22-11-25-C/standard-unit-rates/");
            var response = await request.GetAsync(uri);
            string json = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<StandardUnitRatesReponse>(json);
        }
    }
}
