using EntregaUno.Gestores;

namespace EntregaUno.Menus
{
    public class MenuMonedas
    {
        public static void mostrarMenuMonedas()
        {
            string opcion = string.Empty;

            while (opcion != "5")
            {
                Console.Clear();
                Console.WriteLine($"\n\t MONEDAS.JSON\n");
                Console.WriteLine($"\t 1-. Listar monedas");
                Console.WriteLine($"\t 2-. Crear moneda");
                Console.WriteLine($"\t 3-. Eliminar moneda");
                Console.WriteLine($"\t 4-. Editar valor");
                Console.WriteLine($"\t 5-. Salir");

                Console.Write($"\n\t Seleccione una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"\n\t LISTADO MONEDAS (monedas.json)\n");
                        GestorMonedas.ListarMonedas();
                        Console.WriteLine("\n\t Presione cualquier tecla para volver...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine($"\n\t CREAR MONEDA (monedas.json)\n");
                        GestorMonedas.CrearMonedas();
                        Console.WriteLine("\n\t Presione cualquier tecla para volver...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine($"\n\t ELIMINAR MONEDA (monedas.json)\n");
                        GestorMonedas.EliminarMoneda();
                        Console.WriteLine("\n\t Presione cualquier tecla para volver...");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine($"\n\t EDITAR VALOR MONEDA (monedas.json)\n");
                        GestorMonedas.EditarMoneda();
                        Console.WriteLine("\n\t Presione cualquier tecla para volver...");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("\n\t Presione cualquier tecla para volver...");
                        Console.ReadKey();
                        MenuPrincipal.mostrarMenuPrincipal();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}