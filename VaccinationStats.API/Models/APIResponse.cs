using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VaccinationStats.API.Models
{
    public class APIResponse
    {
        [JsonPropertyName("runid")]
        public int RunId { get; set; }

        [JsonPropertyName("vaccination_county_condensed_data")]
        public List<CountyData> CountyData { get; set; }
    }
}
