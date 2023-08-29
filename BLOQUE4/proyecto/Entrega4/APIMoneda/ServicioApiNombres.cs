using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMoneda
{
    public class ServicioApiNombres
    {
        private readonly HttpClient HttpClient;
        private readonly string ApiUrl;
        public ServicioApiNombres()
        {
            HttpClient = new HttpClient();
            ApiUrl = $"https://api.apilayer.com/exchangerates_data/symbols?apikey=DaMWY6chNhqvbq3w2t8osYPi9Jvx8tg4";
        }

        
        public async Task<string> CallApiAsync()
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync(ApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new HttpRequestException($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error de solicitud HTTP: {ex.Message}");
            }
        }

        
    }
}