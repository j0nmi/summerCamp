using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using BoredApiService.Clases;
using static BoredApiService.Clases.FrankfurtRates;
using static BoredApiService.Clases.FrankfurtCurrencies;

namespace BoredApiService
{
    internal class FrankfurtApiService
    {
        private static HttpClient _httpClient = new HttpClient();


        public FrankfurtApiService()
        {
            _httpClient.BaseAddress = new Uri("https://api.frankfurter.app/");
        }

        public async Task Run()
        {
            // await ObtenerRatios();
            await ObtenerMonedas();
        }

        private async Task ObtenerRatios()
        {
            string monedaBase;
            Console.Write($"\n Seleccione la moneda de origen: ");
            monedaBase = Console.ReadLine().ToUpper();

            var response = await _httpClient.GetAsync($"/latest?from={monedaBase}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<Rootobject>(content);

            Console.WriteLine($" \n RATIOS (frankfurter.app)\n");
            MostrarRatios(resultado.rates);
        }

        private async Task MostrarRatios(Rates rates)
        {
            // Obtenemos todas las propiedades de la clase "Rates"
            PropertyInfo[] properties = typeof(Rates).GetProperties();

            // Mostramos los nombres y valores de cada propiedad
            foreach (PropertyInfo property in properties)
            {
                string nombreMoneda = property.Name;
                float valorMoneda = (float)property.GetValue(rates);

                Console.WriteLine($" {nombreMoneda}: {valorMoneda}");
            }
        }

        private async Task ObtenerMonedas()
        {
            var response = await _httpClient.GetAsync($"/currencies");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var monedas = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);

            Console.WriteLine($"\n CURRENCIES (frankfurter.app)\n");
            foreach (var moneda in monedas)
            {
                Console.WriteLine($" {moneda.Key}: {moneda.Value}");
            }
        }
    }
}
