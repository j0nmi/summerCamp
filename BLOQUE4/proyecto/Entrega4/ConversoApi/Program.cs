using Context;
using Microsoft.EntityFrameworkCore;
using APIMoneda;
using APIPaises;
using APIMonedaNombre;
using Serilog;
using Newtonsoft.Json.Serialization;
using Repositorios;

namespace ConversoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("monedasInfo.txt")
            //.WriteTo.File("monedasInfo.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);


            //+ 1-Add services to the container.
            builder.Host.UseSerilog();

            builder.Services.AddControllers(configure =>
        {
            configure.ReturnHttpNotAcceptable = true;
        })
        .AddNewtonsoftJson(setupAction =>
        {
            setupAction.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
        });  // MVC

            // Documentador de la API    
            // Learn more about configuring Swagger/OpenAPI at
            // https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IRepositorioMonedas, RepositorioMonedas>();
            builder.Services.AddTransient<IRepositorioMonedasNombre, RepositorioMonedasNombre>();
            builder.Services.AddTransient<IRepositorioPais, RepositorioPais>();
            builder.Services.AddTransient<IRepositorioUsuarios, RepositorioUsuarios>();
            builder.Services.AddTransient<IRepositorioHistorial, RepositorioHistorial>();   
            builder.Services.AddTransient<IArrayJson,ArrayJson>();
            builder.Services.AddTransient<IArrayJsonP,ArrayJsonP>();
            builder.Services.AddTransient<IArrayJsonN,ArrayJsonN>();
            

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<ContextoConversor>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:ConexionDatos"]);
            });
            // TIMER PARA OBTENER LAS MONEDAS
            builder.Services.AddHostedService<TimedHostedService>();
            builder.Services.AddHostedService<TimedHostedServiceP>();
            builder.Services.AddHostedService<TimedHostedServiceN>();

            var app = builder.Build();

            //+ 2-Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); // Prepara la documentacion
                app.UseSwaggerUI(); // Genera la documentación
            }



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.Run();
        }
    }
}