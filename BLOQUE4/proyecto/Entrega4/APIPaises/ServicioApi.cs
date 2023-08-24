using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPaises
{
    public class ServicioApi
    {
        private readonly HttpClient HttpClient;
        private readonly string ApiUrl;
        public ServicioApi()
        {
            HttpClient = new HttpClient();
            ApiUrl = $"http://country.io/names.json";
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