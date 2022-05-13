using System;
using System.Linq;

namespace FluentAPIDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionBuilder = PostGreSQLConnectionBuilder.AddDatabase("data")
                                                                .OnHost("google")
                                                                .OnPort(7632)
                                                                .WithUser("Jhay")
                                                                .AndPassword("myPassword")
                                                                .Create();

            Console.WriteLine(connectionBuilder.ConnectionString);
        }
    }
}
