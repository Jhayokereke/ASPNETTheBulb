using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentAPIDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            APIHelper helper = new APIHelper("https://localhost:5001");
            var result = helper.FetchData<string>("api/home", new Dictionary<string, string>{ { "Authorization", "Bearer nvvcfg" } }).Result;

            Console.WriteLine(result);
        }
    }
}
