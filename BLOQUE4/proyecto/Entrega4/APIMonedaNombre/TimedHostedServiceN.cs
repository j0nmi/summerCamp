﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repositorios;

namespace APIMonedaNombre
{
    public class TimedHostedServiceN : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<TimedHostedServiceN> _logger;
        private readonly IConfiguration configuration;
        private Timer? _timer = null;

        public TimedHostedServiceN(ILogger<TimedHostedServiceN> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
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
                .AddScoped<IArrayJsonN, ArrayJsonN>().AddTransient<IRepositorioMonedasNombre, RepositorioMonedasNombre>().AddDbContext<ContextoConversor>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConexionDatos"));
                //options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ConversorBD;Trusted_Connection=True;MultipleActiveResultSets=true");
            })
                .BuildServiceProvider();

            var arrayJson = serviceProvider.GetRequiredService<IArrayJsonN>();

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
