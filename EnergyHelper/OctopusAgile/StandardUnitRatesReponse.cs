using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EnergyHelper.OctopusAgile
{
    internal class StandardUnitRatesReponse
    {
        [JsonPropertyName("results")]
        public Rate[] Results { get; set; }
    }
}
