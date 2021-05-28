using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VaccinationStats.API.Services;

namespace VaccinationStats.API.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IGitHubService _githubServices;

        public ValuesController(IGitHubService githubServices)
        {
            _githubServices = githubServices;
        }

        // GET api/values
        [HttpGet]
        [Route("api/values")]
        public async Task<ActionResult> Get()
        {
            var results = await _githubServices.GetVaccineStats();
            return Ok(results);
        }

        [Route("api/values/top")]
        public async Task<ActionResult> GetTop()
        {
            var results = await _githubServices.GetVaccineStatsTop();
            return Ok(results);

        }
        [Route("api/values/bottom")]
        public async Task<ActionResult> GetBottom()
        {
            var results = await _githubServices.GetVaccineStatsBottom();
            return Ok(results);
        }
    }
}
