using System.Net.Http;

namespace FootballData.Loader
{
    public class HttpLoader
    {
        private static readonly HttpClient _client = new HttpClient();

        public static HttpLoader Create() => new HttpLoader();

        public HttpLoader WithBrowserName(string name) 
        {
            _client.DefaultRequestHeaders.UserAgent.ParseAdd(string.IsNullOrWhiteSpace(name) ? Global.DefaultBrowserName : name);

            return this;
        }

        public HttpClient Build() => _client;
    }
}
