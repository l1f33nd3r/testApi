using System.Threading.Tasks;
using Xunit;

namespace TestHttpTest
{
    public class WeatherForecastTests : IClassFixture<WebApiFixture>
    {
        private readonly WebApiFixture _fixture;

        public WeatherForecastTests(WebApiFixture fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public async Task Get_Test_Endpoint()
        {
            var client = _fixture.GetOauthClient();
            var response = await client.GetAsync("test");
            response.EnsureSuccessStatusCode();
        }
    }
}
