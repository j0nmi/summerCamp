using Entidades.Entities;
using Microsoft.EntityFrameworkCore;
using Entidades.Entities;
namespace Context
{
    public class ContextoConversor : DbContext
    {

        public ContextoConversor(DbContextOptions<ContextoConversor> opciones) : base(opciones)
        {
        }

        public DbSet<Moneda> monedas { get; set; }
        public DbSet<Historial> historial { get; set; }
        public DbSet<Pais> paises { get; set; }
        public DbSet<Usuario> usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // seed the database with dummy data
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario("aaaa@aaaa.com", "123456")
                {
                    id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b31"),
                    idPais = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b06"),
                    fechaNacimiento = new DateTime(1980, 7, 23)
                },
                new Usuario("bbbb@bbbb.com", "123456")
                {
                    id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b32"),
                    idPais = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b05"),
                    fechaNacimiento = new DateTime(1990, 7, 23)
                },
                new Usuario("cccc@cccc.com", "123456")
                {
                    id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b33"),
                    idPais = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b04"),
                    fechaNacimiento = new DateTime(2000, 7, 23)
                }
                );

            modelBuilder.Entity<Pais>().HasData(
               new Pais("Spain", "ESP")
               {
                   id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b01"),
               },
               new Pais("Poland", "PLN")
               {
                   id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b02"),
               },
               new Pais("France", "FR")
               {
                   id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b03"),
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}