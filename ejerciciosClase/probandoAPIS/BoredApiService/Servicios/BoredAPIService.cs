using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BoredApiService
{
    internal class BoredApiService
    {
        private static HttpClient _httpClient = new HttpClient();
        public class BoredApiResponse
        {
            public string Activity { get; set; }
            public string Type { get; set; }
            public int Participants { get; set; }
            public double Price { get; set; }
            public string Link { get; set; }
            public string Key { get; set; }
            public double Accessibility { get; set; }
        }

        public BoredApiService()
        {
            _httpClient.BaseAddress = new Uri("http://www.boredapi.com");
        }

        public async Task Run()
        {
            await EjemploGet();
        }

        private async Task EjemploGet()
        {
            var response = await _httpClient.GetAsync("/api/activity");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var actividad = JsonConvert.DeserializeObject<BoredApiResponse>(content);

            Console.WriteLine($"ACTIVIDAD: {actividad.Activity}");
            Console.WriteLine($"TIPO: {actividad.Type}");
            Console.WriteLine($"PARTICIPANTES: {actividad.Participants}");
            Console.WriteLine($"ENLACE: {actividad.Link}");
            Console.WriteLine($"PRICE: {actividad.Price}");
            Console.WriteLine($"KEY: {actividad.Key}");
        }
    }
}
