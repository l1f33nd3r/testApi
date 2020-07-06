using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using TestHttp;
using Xunit;

namespace TestHttpTest
{
    public class WebApiFixture : IAsyncLifetime
    {
        private TestServer _server;
        public IWebHost WebHost => _server.Host;
        public WebApiFixture()
        {

        }

        public Task InitializeAsync()
        {
            var host = new WebHostBuilder()
                .UseEnvironment("Local")
                .UseStartup<Startup>();

            _server = new TestServer(host);
            return Task.CompletedTask;
        }

        public HttpClient GetOauthClient()
        {
            try
            {
                return _server.CreateClient();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
