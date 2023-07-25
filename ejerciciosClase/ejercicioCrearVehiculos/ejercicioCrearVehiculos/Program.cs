using Entidades;
namespace ejercicioCrearVehiculos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"\n\tVEHICULOS\n");

            var vehiculo1 = new
            {
                AnoCompra = new DateTime(2020, 01, 15).Year,
                Color = "Rojo"
            };
            Console.WriteLine($"\n\tVehiculo 1 - Año de compra: {vehiculo1.AnoCompra} Color: {vehiculo1.Color}");

            var vehiculo2 = new
            {
                Marca = "Audi",
                Modelo = "Q7"
            };
            Console.WriteLine($"\n\tVehiculo 2 - Marca: {vehiculo2.Marca} Modelo: {vehiculo2.Modelo}");

            var vehiculo3 = new
            {
                AnoCompra = new DateTime(2020, 01, 15).Year,
                Color = "Rojo",
                Marca = "Audi",
                Modelo = "Q7"
            };
            Console.WriteLine($"\n\tVehiculo 3 - Año de compra: {vehiculo3.AnoCompra} Color: {vehiculo3.Color} Marca: {vehiculo2.Marca} Modelo: {vehiculo2.Modelo}");



        }
    }
}