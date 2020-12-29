using System;
using System.IO;
using System.Windows.Forms;
using RestSharp;

namespace WebDataParser
{
    public partial class WebDataParser : Form
    {
        string covidData;

        public WebDataParser()
        {
            InitializeComponent();
        }

        private string getCovidData(string queryURL)
        {
            //var client = new RestClient("https://api.covid19api.com/total/country/poland");
            //var client = new RestClient("https://api.covid19api.com/world/total");
            //var client = new RestClient("https://api.covid19api.com/dayone/country/poland/status/confirmed/live");
            //var client = new RestClient("https://api.covid19api.com/summary");
            var client = new RestClient(queryURL);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            string parsedData = response.Content;
            //Console.WriteLine(parsedData);

            //string parsedData = responseContent;
            parsedData = parsedData.Replace("},", "},\n");

            //Zapis do pliku
            //string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output.txt");
            //destPath = destPath.Replace("WebDataParser\\bin\\Debug\\netcoreapp3.1\\", "");
            //File.WriteAllText(destPath, dataToBeSaved.ToString());

            return parsedData.ToString();
        }

        private void btn_AllCasesPL_Click(object sender, EventArgs e)
        {
            covidData = getCovidData("https://api.covid19api.com/total/country/poland");
            if (covidData != null)
            {
                //Wyświetl ekran z danymi
                var openWindow = new ViewDataWindow(covidData);
                openWindow.Show();
            }
        }

        private void btn_AllCasesWorld_Click(object sender, EventArgs e)
        {
            covidData = getCovidData("https://api.covid19api.com/world/total");
            if (covidData != null)
            {
                //Wyświetl ekran z danymi
                var openWindow = new ViewDataWindow(covidData);
                openWindow.Show();
            }
        }

        private void btn_ConfirmedPL_Click(object sender, EventArgs e)
        {
            covidData = getCovidData("https://api.covid19api.com/dayone/country/poland/status/confirmed/live");
            if (covidData != null)
            {
                //Wyświetl ekran z danymi
                var openWindow = new ViewDataWindow(covidData);
                openWindow.Show();
            }
        }

        private void btn_Summary_Click(object sender, EventArgs e)
        {
            covidData = getCovidData("https://api.covid19api.com/summary");
            if (covidData != null)
            {
                //Wyświetl ekran z danymi
                var openWindow = new ViewDataWindow(covidData);
                openWindow.Show();
            }
        }
    }
}
