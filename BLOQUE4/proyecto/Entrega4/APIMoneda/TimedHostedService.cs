using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repositorios;

namespace APIMoneda
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<TimedHostedService> _logger;
        private Timer? _timer = null;

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(30));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            ////Ejecuta la consulta de monedas a la API
            var serviceProvider = new ServiceCollection()
                .AddScoped<IArrayJson, ArrayJson>().AddTransient<IRepositorioMonedas, RepositorioMonedas>().AddDbContext<ContextoConversor>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ConversorBD;Trusted_Connection=True;MultipleActiveResultSets=true");
            })
                .BuildServiceProvider();

            var arrayJson = serviceProvider.GetRequiredService<IArrayJson>();

            _logger.LogInformation("Has llamado a la API");
            arrayJson.Ejecutar();
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }


    }
}
