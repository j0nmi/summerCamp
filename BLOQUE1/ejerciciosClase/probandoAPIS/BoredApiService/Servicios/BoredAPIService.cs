using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static BoredApiService.Clases.BoredActivity;

namespace BoredApiService
{
    internal class BoredApiService
    {
        private static HttpClient _httpClient = new HttpClient();
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

            Console.WriteLine($" \n ACTIVIDAD (boredapi.com)\n");
            Console.WriteLine($" ACTIVIDAD: {actividad.Activity}");
            Console.WriteLine($" TIPO: {actividad.Type}");
            Console.WriteLine($" PARTICIPANTES: {actividad.Participants}");
            Console.WriteLine($" PRICE: {actividad.Price}");
            Console.WriteLine($" ACCESIBILIDAD: {actividad.Accessibility}");
        }
    }
}
