using EjemploConversorMVC.Servicios;
namespace EjemploConversorMVC
{
    public class Program
    {
        // 1-. Crear interfaz IMail
        // 2-. Crear 2 Clases: MailDesarrollo, MailProduccion
        // 3-. Configurar el servicio
        // 4-. Agregar interfaz en el ctor
        // 5-. Envíar un correo en el momento que va a /Home/Privacy
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); // MVC (ModeloVistaControlador)

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IServicioMonedas, ServicioMonedas>();
            builder.Services.AddScoped<IServicioMonedas,ServicioCriptoMonedas>();

            builder.Services.AddScoped<IMail, ServicioMailDesarrollo>();
            builder.Services.AddScoped<IMail, ServicioMailProduccion>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}