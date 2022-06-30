using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace CallingApiTask
{
    internal class Program
    {
         static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/weather?lat=34&lon=73&appid=9cde4671eeddf0e1ab050d0accdced69");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            GetWeather(client).Wait();
        }

        static async Task GetWeather(HttpClient client)
        {
            using (client)
            {
                HttpResponseMessage res = await client.GetAsync("");

                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    string weather = await res.Content.ReadAsStringAsync();

                    JObject jobj = JObject.Parse(weather);

                    Console.WriteLine("Weather Station: Abbotabad");
                    Console.WriteLine(jobj.ToString());
                 
                    Console.ReadLine();
                }
            }
        }
    }
}
