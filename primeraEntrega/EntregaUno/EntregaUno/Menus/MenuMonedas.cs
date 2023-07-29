using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EntregaUno.Clases;

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
                        ListarMonedas();
                        Console.WriteLine("\n\t Presione cualquier tecla para volver...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine($"\n\t CREAR MONEDA (monedas.json)\n");
                        CrearMonedas();
                        Console.WriteLine("\n\t Presione cualquier tecla para volver...");
                        Console.ReadKey(); ;
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine($"\n\t ELIMINAR MONEDA (monedas.json)\n");
                        EliminarMoneda();
                        Console.WriteLine("\n\t Presione cualquier tecla para volver...");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine($"\n\t EDITAR VALOR MONEDA (monedas.json)\n");
                        EditarMoneda();
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

                static void ListarMonedas()
                {

                    // Ruta del fichero .json
                    string rutaJson = "..\\..\\..\\BBDD\\monedas.json";

                    // Guarda el contenido de monedas.json en la variable json
                    string json = File.ReadAllText(rutaJson);

                    // Deserializa el json en la lista de monedas
                    List<Monedas> listaMonedas = JsonConvert.DeserializeObject<List<Monedas>>(json);

                    foreach (Monedas moneda in listaMonedas)
                    {
                        string name = moneda.nombre;
                        string code = moneda.codigo;
                        float value = moneda.valorEnDolares;
                        Console.WriteLine($"\t Moneda: {name} | Codigo: {code} | Valor en USD: {value}.");
                    }
                }

                static void CrearMonedas()
                {
                    // Pedimos valores
                    Console.Write($"\t Nombre de la nueva moneda: ");
                    string nombreNuevaMoneda = Console.ReadLine();
                    Console.Write($"\t Codigo de la nueva moneda: ");
                    string codigoNuevaMoneda = Console.ReadLine();
                    Console.Write($"\t Valor de la nueva moneda: ");
                    float valorEnDolaresNuevaMoneda = float.Parse(Console.ReadLine());

                    // Crea una nueva instancia de la clase Monedas con los valores
                    Monedas nuevaMoneda = new Monedas
                    {
                        nombre = nombreNuevaMoneda,
                        codigo = codigoNuevaMoneda,
                        valorEnDolares = valorEnDolaresNuevaMoneda
                    };

                    string rutaJson = "..\\..\\..\\BBDD\\monedas.json";

                    string json = File.ReadAllText(rutaJson);
                    List<Monedas> listaMonedas = JsonConvert.DeserializeObject<List<Monedas>>(json);

                    listaMonedas.Add(nuevaMoneda);

                    // Serializa la lista de vuelta a formato JSON
                    string nuevoJson = JsonConvert.SerializeObject(listaMonedas, Formatting.Indented);

                    // Guarda el contenido actualizado en el archivo "monedas.json"
                    File.WriteAllText(rutaJson, nuevoJson);
                    Console.WriteLine($"\n\t Nueva moneda agregada correctamente.");
                }

                static void EditarMoneda()
                {
                    Console.Write($"\t Ingrese el código de la moneda que desea editar: ");
                    string codigoMoneda = Console.ReadLine().ToUpper();

                    string rutaJson = "..\\..\\..\\BBDD\\monedas.json";

                    string json = File.ReadAllText(rutaJson);
                    List<Monedas> listaMonedas = JsonConvert.DeserializeObject<List<Monedas>>(json);

                    // Busca la moneda en la lista por su código
                    Monedas monedaSeleccionada = null;
                    foreach (Monedas moneda in listaMonedas)
                    {
                        if (moneda.codigo.ToUpper() == codigoMoneda)
                        {
                            monedaSeleccionada = moneda;
                            break;
                        }
                    }

                    if (monedaSeleccionada == null)
                    {
                        Console.WriteLine($"\t La moneda con el código ingresado no existe.");
                        return;
                    }

                    // Muestra la información actual de la moneda seleccionada
                    Console.WriteLine($"\t Moneda seleccionada: {monedaSeleccionada.nombre} | Codigo: {monedaSeleccionada.codigo} | Valor en USD: {monedaSeleccionada.valorEnDolares}.");

                    Console.Write($"\t Nuevo valor en dólares de la moneda: ");
                    float nuevoValor = float.Parse(Console.ReadLine());
                    monedaSeleccionada.valorEnDolares = nuevoValor;
                    string nuevoJson = JsonConvert.SerializeObject(listaMonedas, Formatting.Indented);
                    File.WriteAllText(rutaJson, nuevoJson);

                    Console.WriteLine($"\t Moneda editada correctamente.");
                }

                static void EliminarMoneda()
                {
                    ListarMonedas();
                    Console.Write($"\n\t Ingrese el código de la moneda que desea eliminar: ");
                    string codigoMoneda = Console.ReadLine().ToUpper();
                    string rutaJson = "..\\..\\..\\BBDD\\monedas.json";
                    string json = File.ReadAllText(rutaJson);
                    List<Monedas> listaMonedas = JsonConvert.DeserializeObject<List<Monedas>>(json);

                    Monedas monedaSeleccionada = null;
                    foreach (Monedas moneda in listaMonedas)
                    {
                        if (moneda.codigo.ToUpper() == codigoMoneda)
                        {
                            monedaSeleccionada = moneda;
                            break;
                        }
                    }

                    if (monedaSeleccionada == null)
                    {
                        Console.WriteLine($"\t La moneda con el código ingresado no existe.");
                        return;
                    }

                    listaMonedas.Remove(monedaSeleccionada);
                    string nuevoJson = JsonConvert.SerializeObject(listaMonedas, Formatting.Indented);
                    File.WriteAllText(rutaJson, nuevoJson);
                    Console.WriteLine($"\t Moneda eliminada correctamente.");
                }
            }
        }
    }
}
