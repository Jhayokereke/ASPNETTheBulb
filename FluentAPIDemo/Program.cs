using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FluentAPIDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            APIHelper helper = new APIHelper("https://localhost:44300");

            var result = helper.PostData<Data, PostRequest>("api/home", new PostRequest { Id = "dguhdvah", Name = "TheBulb" }, new Dictionary<string, string>{ { "Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImpoYXlAdGhlYnVsYi5jb20iLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE2NTI3MDI3MDAsImV4cCI6MTY1MjcwMzMwMCwiaWF0IjoxNjUyNzAyNzAwfQ.l0-5SiSTIS25_1XNL_gjvcS0xj127454c6qT64GX2zw" } }).Result;

            Console.WriteLine(result);
        }

        internal class Data
        {
            public string Id { get; set; }
            public string Name { get; set; }
            [JsonPropertyName("time")]
            public string TimeOfRegistration { get; set; }
        }

        public class PostRequest
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}
