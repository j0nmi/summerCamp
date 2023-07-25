using Entidades;
namespace ejercicioCrearVehiculos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creamos la lista para los vehiculos
            var list = new List<Vehiculo>();

            // Iniciamos la variable seleccion
            string opcion = string.Empty;

            while (opcion != "5") // Mostramos el menu mientras seleccion != 5
            {
                Console.Clear();
                Console.WriteLine($"\n\t CREACION DE VEHICULOS");
                Console.WriteLine($"\n\t 1-. Crear vehiculo con Año de compra y Color");
                Console.WriteLine($"\t 2-. Crear vehiculo con Marca y Modelo");
                Console.WriteLine($"\t 3-. Crear vehiculo con todos los datos");
                Console.WriteLine($"\t 4-. Mostrar vehiculos creados");
                Console.WriteLine($"\t 5-. Salir");

                // Pedir opcion
                Console.Write($"\n\n\t Seleccione una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"\n\t CONSTRUCTOR 1 (Año de compra y Color) ");
                        Console.WriteLine($"\n");

                        // Pedimos el año y lo convertimos a int
                        Console.Write($"\t Introduce el año de compra: ");
                        int anoCompra = Convert.ToInt32(Console.ReadLine());

                        // Pedimos el color
                        Console.Write($"\t Introduce el color: ");
                        string color = Console.ReadLine();

                        // Creamos el vehiculo y lo agregamos a la lista
                        list.Add(new Vehiculo(anoCompra, color));

                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine($"\n\t CONSTRUCTOR 2 (Marca y Modelo) ");
                        Console.WriteLine($"\n");
                        Console.Write($"\t Introduce la marca: ");
                        string marca = Console.ReadLine();
                        Console.Write($"\t Introduce el modelo: ");
                        string modelo = Console.ReadLine();
                        list.Add(new Vehiculo(marca, modelo));
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine($"\n\t CONSTRUCTOR 3 (Completo) ");
                        Console.WriteLine($"\n");
                        Console.Write($"\t Introduce el año de compra: ");
                        int anoCompra2 = Convert.ToInt32(Console.ReadLine());
                        Console.Write($"\t Introduce el color: ");
                        string color2 = Console.ReadLine();
                        Console.Write($"\t Introduce la marca: ");
                        string marca2 = Console.ReadLine();
                        Console.Write($"\t Introduce el modelo: ");
                        string modelo2 = Console.ReadLine();
                        list.Add(new Vehiculo(anoCompra2, color2, marca2, modelo2));
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine($"\n\t LISTADO DE VEHICULOS ");
                        Console.WriteLine($"\n");
                        foreach (var vehiculo in list)
                        {
                            Console.WriteLine($"\t VEHICULO | Año: {vehiculo.AnoCompra} Color: {vehiculo.Color} Marca: {vehiculo.Marca} Modelo: {vehiculo.Modelo}");
                        }
                        break;

                    case "5":
                        Console.WriteLine($"\n\tSaliendo del programa...");
                        break;

                    default:
                        Console.WriteLine($"\n\tOpción inválida. Intente nuevamente.");
                        break;
                }

                // Pausa para que el usuario pueda ver el resultado antes de volver al menú
                Console.WriteLine("\n\tPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
