using EntregaUno.Clases;
using EntregaUno.Gestores;

namespace EntregaUno.Menus
{
    public class MenuConversor
    {

        List<HistorialConversiones> conversionHistory = new List<HistorialConversiones>();
        public static void mostrarMenuConversor()
        {
            Console.Clear();

            // Crear las variables vacías
            double cantidad = 0;
            decimal resultadoConversion = 0;
            string monedaOrigen = string.Empty;
            string monedaDestino = string.Empty;
            string seleccion = string.Empty;
            bool datosCompletos = false;

            while (seleccion != "6")
            {
                // Mostrar el menu
                Console.WriteLine($"\n\t MENU CONVERSOR\n" +
                                  $"\n\t 1-. Cantidad a convertir: {cantidad}" +
                                  $"\n\t 2-. Moneda de origen: {monedaOrigen}" +
                                  $"\n\t 3-. Moneda de destino: {monedaDestino}" +
                                  $"\n\t 4-. Convertir" +
                                  $"\n\t 5-. Historial" +
                                  $"\n\t 6-. Salir");

                Console.Write($"\n\t Seleccione una opción (1-5): ");
                seleccion = Console.ReadLine();

                switch (seleccion)
                {
                    case "1":
                        // Pedir la cantidad a convertir (cantidad)
                        Console.Write($"\t Introduzca la cantidad a convertir: ");
                        while (!double.TryParse(Console.ReadLine(), out cantidad))
                        {
                            Console.Write("\t ERROR | Cantidad inválida. Introduzca un número válido: ");
                        }
                        Console.Clear();
                        break;
                    case "2":
                        // Pedir la moneda de origen (monedaOrigen)
                        Console.Write($"\t Seleccione la moneda de origen: ");
                        monedaOrigen = Console.ReadLine().ToUpper();
                        while (!GestorMonedas.ExisteMoneda(monedaOrigen))
                        {
                            Console.Write($"\t ERROR | La moneda con código '{monedaOrigen}' no existe. Introduzca un código válido: ");
                            monedaOrigen = Console.ReadLine().ToUpper();
                        }
                        Console.Clear();
                        break;
                    case "3":
                        // Pedir la moneda de destino (monedaDestino)
                        Console.Write($"\t Seleccione la moneda de destino: ");
                        monedaDestino = Console.ReadLine().ToUpper();
                        while (!GestorMonedas.ExisteMoneda(monedaDestino))
                        {
                            Console.Write($"\t ERROR | La moneda con código '{monedaDestino}' no existe. Introduzca un código válido: ");
                            monedaDestino = Console.ReadLine().ToUpper();
                        }
                        Console.Clear();
                        break;
                    case "4":
                        if (datosCompletos == true) // Si se han introducido todos los datos
                        {
                            Console.WriteLine($"\t Convirtiendo... ");
                            // Hay que sacar un método para que realice la conversión
                            Console.WriteLine($"\n\t El cambio de {cantidad} {monedaOrigen} a {monedaDestino} son: {resultadoConversion}");
                            Console.WriteLine("\n\t Presione cualquier tecla para volver...");
                            Console.ReadKey();
                            Console.Clear();

                            HistorialConversiones registro = new HistorialConversiones
                            {
                                Cantidad = cantidad,
                                MonedaOrigen = monedaOrigen,
                                MonedaDestino = monedaDestino,
                                ResultadoConversion = resultadoConversion,
                                FechaConversion = DateTime.Now.ToString(),
                            };

                            // Llamamos al método CrearRegistroHistorial para guardar el registro en historial.json
                            try
                            {
                                GestorHistorial.CrearRegistroHistorial(registro);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"\t ERROR | Error al guardar el registro en el historial: {ex.Message}");
                            }

                            // Limpiamos los valores tras realizar una conversión y almacenarla en el historial
                            cantidad = 0;
                            resultadoConversion = 0;
                            monedaOrigen = string.Empty;
                            monedaDestino = string.Empty;
                        }
                        else // Si falta por introducir algún dato
                        {
                            Console.WriteLine($"\t ERROR | Faltan datos para realizar la conversión!");
                            Console.WriteLine("\t Presione cualquier tecla para volver...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine($"\n\t HISTORIAL DE CONVERSIONES");
                        Console.WriteLine("");
                        GestorHistorial.ListarHistorial();
                        Console.WriteLine("\n\t Presione cualquier tecla para volver...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                        Console.WriteLine("\n\t Presione cualquier tecla para volver...");
                        Console.ReadKey();
                        Console.Clear();
                        MenuPrincipal.mostrarMenuPrincipal();
                        break;
                    default:
                        Console.Clear();
                        break;
                }

                // Comprobamos que se han introducido todos los datos necesarios y que cantidad es mayor a 0
                if (!string.IsNullOrEmpty(monedaOrigen) && !string.IsNullOrEmpty(monedaDestino) && cantidad > 0)
                {
                    datosCompletos = true;
                }
            }
        }
    }
}