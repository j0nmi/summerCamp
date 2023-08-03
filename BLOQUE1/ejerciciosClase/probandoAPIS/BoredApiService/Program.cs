using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BoredApiService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //BoredApiService boredApiService = new BoredApiService();
            //await boredApiService.Run();

            //FrankfurtApiService currencyApiService = new FrankfurtApiService();
            //await currencyApiService.Run();

            FrankfurtApiService currenciesService = new FrankfurtApiService();
            await currenciesService.Run();
        }
    }

}

