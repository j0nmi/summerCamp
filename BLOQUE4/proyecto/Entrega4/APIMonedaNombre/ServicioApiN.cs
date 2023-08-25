using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMonedaNombre
{
    public class ServicioApiN
    {
        private readonly HttpClient HttpClient;
        private readonly string ApiUrl;
        public ServicioApiN()
        {
            HttpClient = new HttpClient();
            ApiUrl = $"https://api.ratesexchange.eu/client/currencies?apiKey=58eedc56-8423-490a-b44d-7125ab9172fd";
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