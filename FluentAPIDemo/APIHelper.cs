using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FluentAPIDemo
{
    public class APIHelper
    {
        //https://jsonmock.hackerrank.com/api/article_users/search%22
        private HttpClient _client;

        public APIHelper(string baseUrl)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
        }

        public Dictionary<string, string> SpecificUrls { get; set; }

        public async Task<T> FetchData<T>(string url, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    _client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            var jsonString = await _client.GetAsync(url).Result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(jsonString);
        }


    }
}
