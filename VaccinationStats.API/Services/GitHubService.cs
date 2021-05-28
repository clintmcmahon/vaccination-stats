using LazyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using VaccinationStats.API.Models;

namespace VaccinationStats.API.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly HttpClient client = new HttpClient();
        private readonly IAppCache _cache;
        private readonly TimeSpan _cacheExpiry = new TimeSpan(12, 0, 0);
        public GitHubService(IAppCache cache)
        {
            _cache = cache;
        }

        public async Task<List<CountyData>> GetVaccineStats()
        {
            return await _cache.GetOrAddAsync("GetCountyData", async () =>
            {
                return await GetCountyData();
            }, _cacheExpiry);
        }

        public async Task<List<CountyData>> GetVaccineStatsTop()
        {
            var countydata =  await _cache.GetOrAddAsync("GetCountyData", async () =>
            {
                return await GetCountyData();
            }, _cacheExpiry);

            return countydata.Where(x => 
                x.Series_Complete_Pop_Pct != null)
                .OrderByDescending(x => x.Series_Complete_Pop_Pct)
                .ToList();
        }

        public async Task<List<CountyData>> GetVaccineStatsBottom()
        {
            var countydata = await _cache.GetOrAddAsync("GetCountyData", async () =>
            {
                return await GetCountyData();
            }, _cacheExpiry);

            return countydata.Where(x=>
                x.Series_Complete_Pop_Pct != null)
                .OrderBy(x => x.Series_Complete_Pop_Pct)
                .ToList();
        }

        private async Task<List<CountyData>> GetCountyData()
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("User-Agent", "");

                string baseUrl = $"https://raw.githubusercontent.com/mattwaite/cdc-county-vaccination-data/main/countyvaccinations.json";

                var streamTask = client.GetStreamAsync(baseUrl);
                var apiResponse = await JsonSerializer.DeserializeAsync<APIResponse>(await streamTask);
                return apiResponse.CountyData;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
           
        }
    }

    public interface IGitHubService
    {
        Task<List<CountyData>> GetVaccineStats();
        Task<List<CountyData>> GetVaccineStatsTop();
        Task<List<CountyData>> GetVaccineStatsBottom();
    }
}
