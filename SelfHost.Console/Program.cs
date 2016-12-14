using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api;
using Microsoft.Owin.Hosting;
namespace SelfHost.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var typeLoaded = typeof(DefaultController);

            string baseAddress = "http://localhost:9001/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/status").Result;

                System.Console.WriteLine(response);
                System.Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }

            System.Console.ReadLine(); 
        }
    }
}
