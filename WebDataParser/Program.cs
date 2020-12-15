using System;
using System.IO;
using RestSharp;

namespace WebDataParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //var client = new RestClient("https://api.covid19api.com/total/country/poland");
            //var client = new RestClient("https://api.covid19api.com/world/total");
            //var client = new RestClient("https://api.covid19api.com/dayone/country/poland/status/confirmed/live");
            var client = new RestClient("https://api.covid19api.com/summary");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            string responseContent = response.Content;
            Console.WriteLine(responseContent);

            string dataToBeSaved = responseContent;
            dataToBeSaved = dataToBeSaved.Replace("},", "},\n");
            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output.txt");
            destPath = destPath.Replace("WebDataParser\\bin\\Debug\\netcoreapp3.1\\", "");

            File.WriteAllText(destPath, dataToBeSaved.ToString());
        }
    }
}
