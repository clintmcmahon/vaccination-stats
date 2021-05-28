using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationStats.API.Models
{
    public class CountyData
    {
        public DateTime Date { get; set; }
        public string FIPS { get; set; }
        public string StateName { get; set; }
        public string StateAbbr { get; set; }
        public string County { get; set; }
        public int? Series_Complete_18Plus { get; set; }
        public double? Series_Complete_18PlusPop_Pct { get; set; }
        public int? Series_Complete_65Plus { get; set; }
        public double? Series_Complete_65PlusPop_Pct { get; set; }
        public int? Series_Complete_Yes { get; set; }
        public double? Series_Complete_Pop_Pct { get; set; }
        public double? Completeness_pct { get; set; }
        public int? Census2019_12PlusPop { get; set; }
        public int? Series_Complete_12Plus { get; set; }
        public double? Series_Complete_12PlusPop_Pct { get; set; }
    }
}
