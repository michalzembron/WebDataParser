using System;
using RestSharp;

namespace WebDataParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://api.covid19api.com/");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
