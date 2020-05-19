using System;
using System.Net.Http;
using Microsoft.Extensions.Options;

namespace Dock.Apps.InfoApi.Request
{
    public class UserHttpClient : IUserHttpClient
    {        
        private readonly HttpClient _client;
        public UserHttpClient(HttpClient client, IOptions<UserApiConfig> apiConfig)
        {
            _client = client;
            _client.BaseAddress = new Uri(apiConfig.Value.BaseUrl + "/api/");
        }

        public string[] GetUsers()
        {
            var responseTask = _client.GetAsync("Users");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<string[]>();
                readTask.Wait();
                return readTask.Result;
            }
            else
            {
                throw new Exception("Request failed. Status = " + result.StatusCode);
            }
        }
    }
}
