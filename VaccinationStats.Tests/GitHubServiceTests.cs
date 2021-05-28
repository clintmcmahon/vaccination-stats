using System;
using System.Threading.Tasks;
using VaccinationStats.API.Services;
using Xunit;
using Moq;
using LazyCache;

namespace VaccinationStats.Tests
{
    public class GitHubServiceTests
    {
        [Fact]
        public void Get_CountData_Success()
        {
            var mockAppCache = new Mock<IAppCache>();
            var gitHubService = new GitHubService(mockAppCache.Object);

            var results = gitHubService.GetVaccineStats().Result;

            Assert.True(results.Count > 0);
        }
    }
}
