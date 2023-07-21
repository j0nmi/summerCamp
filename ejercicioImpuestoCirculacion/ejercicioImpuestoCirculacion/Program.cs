using Entidades;
namespace ejercicioImpuestoCirculacion
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Inicializamos el objeto
            var coche1 = new Coche
            {
                Nombre = "BMW",
                ValorBase = 30000,
                AnoMatriculacion = new DateTime(2020, 01, 15).Year
            };
            coche1.FijarEtiqueta(Coche.Etiqueta.EtiquetaSIN);

            var coche2 = new Coche
            {
                Nombre = "Mercedes",
                ValorBase = 8000,
                AnoMatriculacion = new DateTime(2008, 10, 21).Year
            };
            coche2.FijarEtiqueta(Coche.Etiqueta.EtiquetaB);

            var coche3 = new Coche
            {
                Nombre = "Audi",
                ValorBase = 25000,
                AnoMatriculacion = new DateTime(2010, 04, 29).Year
            };
            coche3.FijarEtiqueta(Coche.Etiqueta.EtiquetaCERO);


            // Creamos la lista genérica y agregamos los coches
            var lista = new List<Coche>();
            lista.Add(coche1);
            lista.Add(coche2);
            lista.Add(coche3);


            // OTRA FORMA DE CREAR LA LISTA Y LOS COCHES
            //
            // var lista = new List<Vehiculo>
            // {
            //    new Coche { Nombre = "Mercedes", AnoMatriculacion = new DateTime(2010, 04, 29).Year, ValorBase = 2000, Etiqueta = "Sin etiqueta" },
            //    new Coche { Nombre = "Volkswagen", AnoMatriculacion = new DateTime(2010, 04, 29).Year, ValorBase = 1000, Etiqueta = "Etiqueta CERO" },
            //    new Coche { Nombre = "Audi", AnoMatriculacion = new DateTime(2010, 04, 29).Year, ValorBase = 2500, Etiqueta = "Etiqueta C" },
            //    new Coche { Nombre = "BMW", AnoMatriculacion = new DateTime(2010, 04, 29).Year, ValorBase = 1200, Etiqueta = "Etiqueta ECO" },
            //    new Coche { Nombre = "Fiat", AnoMatriculacion = new DateTime(2010, 04, 29).Year, ValorBase = 3000, Etiqueta = "Etiqueta B" }
            // };
            //

            foreach (var coche in lista)
            {
                Console.WriteLine($"\n\tVehiculo: {coche.Nombre}  Año: {coche.AnoMatriculacion} Etiqueta: {coche.EtiquetaContaminacion} Impuesto de Circulacion Total: {coche.CalcularImpuestoCirculacion()}.");
            }
        }
    }
}