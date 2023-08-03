using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace BoredApiService
{
    internal class FrankfurtApiService
    {
        private static HttpClient _httpClient = new HttpClient();


        public class Rootobject
        {
            public float amount { get; set; }
            public string monedaBase { get; set; }
            public string date { get; set; }
            public Rates rates { get; set; }
        }

        public class Rates
        {
            public float AUD { get; set; }
            public float BGN { get; set; }
            public float BRL { get; set; }
            public float CAD { get; set; }
            public float CHF { get; set; }
            public float CNY { get; set; }
            public float CZK { get; set; }
            public float DKK { get; set; }
            public float GBP { get; set; }
            public float HKD { get; set; }
            public float HUF { get; set; }
            public float IDR { get; set; }
            public float ILS { get; set; }
            public float INR { get; set; }
            public float ISK { get; set; }
            public float JPY { get; set; }
            public float KRW { get; set; }
            public float MXN { get; set; }
            public float MYR { get; set; }
            public float NOK { get; set; }
            public float NZD { get; set; }
            public float PHP { get; set; }
            public float PLN { get; set; }
            public float RON { get; set; }
            public float SEK { get; set; }
            public float SGD { get; set; }
            public float THB { get; set; }
            public float TRY { get; set; }
            public float USD { get; set; }
            public float ZAR { get; set; }
        }

        public FrankfurtApiService()
        {
            _httpClient.BaseAddress = new Uri("https://api.frankfurter.app/");
        }

        public async Task Run()
        {
            await ObtenerMonedas();
        }

        private async Task ObtenerMonedas()
        {
            string monedaBase;
            Console.Write($" Seleccione la moneda de origen: ");
            monedaBase = Console.ReadLine().ToUpper();

            var response = await _httpClient.GetAsync($"/latest?from={monedaBase}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<Rootobject>(content);

            Console.WriteLine($" \n MONEDAS (frankfurter.app)\n");
            MostrarMonedas(resultado.rates);
        }

        private async Task MostrarMonedas(Rates rates)
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
    }
}
