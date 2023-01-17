using System.Text.Json.Serialization;

namespace EnergyHelper.OctopusAgile
{
    internal class Rate
    {
        [JsonPropertyName("value_exc_vat")]
        public double ValueExcludingVat { get; set; }
        
        [JsonPropertyName("value_inc_vat")]
        public double ValueIncludingVat { get; set; }
        
        [JsonPropertyName("valid_from")]
        public DateTime ValidFrom { get; set; }
        
        [JsonPropertyName("valid_to")]
        public DateTime ValidTo { get; set; }
    }
}
