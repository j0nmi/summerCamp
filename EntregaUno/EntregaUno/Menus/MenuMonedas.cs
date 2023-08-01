using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using EntregaUno.Clases;

namespace EntregaUno.Menus
{
    public class MenuMonedas
    {
        // Ruta del fichero JSON.
        private const string rutaMonedasJson = @"..\..\..\BBDD\monedas.json";

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
                        Console.ReadKey();
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
            }
        }

        static void ListarMonedas()
        {
            // Guarda el contenido de monedas.json en la variable json
            string json = File.ReadAllText(rutaMonedasJson);

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
            string nombreNuevaMoneda;
            Console.Write($"\t Codigo de la nueva moneda: ");
            while (string.IsNullOrEmpty(nombreNuevaMoneda = Console.ReadLine()))
            {
                Console.Write("\t ERROR | Nombre de moneda inválido. Introduce un nombre de moneda válido: ");
            }
            string codigoNuevaMoneda;
            Console.Write($"\t Codigo de la nueva moneda: ");
            while (string.IsNullOrEmpty(codigoNuevaMoneda = Console.ReadLine()))
            {
                Console.Write("\t ERROR | Código de moneda inválido. Introduce un código de moneda válido: ");
            }
            float valorEnDolaresNuevaMoneda;
            Console.Write($"\t Valor de la nueva moneda: ");
            while (!float.TryParse(Console.ReadLine(), out valorEnDolaresNuevaMoneda))
            {
                Console.Write("\t ERROR | Valor inválido. Introduzca un número válido: ");
            }

            // Crea una nueva instancia de la clase Monedas con los valores
            Monedas nuevaMoneda = new Monedas
            {
                nombre = nombreNuevaMoneda,
                codigo = codigoNuevaMoneda,
                valorEnDolares = valorEnDolaresNuevaMoneda
            };

            string json = File.ReadAllText(rutaMonedasJson);
            List<Monedas> listaMonedas = JsonConvert.DeserializeObject<List<Monedas>>(json);

            listaMonedas.Add(nuevaMoneda);

            // Serializa la lista de vuelta a formato JSON
            string nuevoJson = JsonConvert.SerializeObject(listaMonedas, Formatting.Indented);

            // Guarda el contenido actualizado en el archivo "monedas.json"
            File.WriteAllText(rutaMonedasJson, nuevoJson);
            Console.WriteLine($"\n\t Nueva moneda agregada correctamente.");
        }

        static void EditarMoneda()
        {
            ListarMonedas();
            Console.Write($"\n\t Ingrese el código de la moneda que desea editar: ");
            string codigoMoneda = Console.ReadLine().ToUpper();

            string json = File.ReadAllText(rutaMonedasJson);
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

            float nuevoValor;
            Console.Write($"\t Nuevo valor en dólares de la moneda: ");
            while (!float.TryParse(Console.ReadLine(), out nuevoValor))
            {
                Console.Write("\t ERROR | Valor inválido. Introduzca un número válido: ");
            }
            monedaSeleccionada.valorEnDolares = nuevoValor;
            string nuevoJson = JsonConvert.SerializeObject(listaMonedas, Formatting.Indented);
            File.WriteAllText(rutaMonedasJson, nuevoJson);

            Console.WriteLine($"\t Moneda editada correctamente.");
        }

        static void EliminarMoneda()
        {
            ListarMonedas();
            Console.Write($"\n\t Ingrese el código de la moneda que desea eliminar: ");
            string codigoMoneda = Console.ReadLine().ToUpper();
            string json = File.ReadAllText(rutaMonedasJson);
            List<Monedas> listaMonedas = JsonConvert.DeserializeObject<List<Monedas>>(json);

            // Buscamos la moneda por su código mediante una expresión lambda
            Monedas monedaSeleccionada = listaMonedas.Find(moneda => moneda.codigo.ToUpper() == codigoMoneda);

            if (monedaSeleccionada == null)
            {
                Console.WriteLine($"\t La moneda con el código ingresado no existe.");
                return;
            }

            listaMonedas.Remove(monedaSeleccionada);
            string nuevoJson = JsonConvert.SerializeObject(listaMonedas, Formatting.Indented);
            File.WriteAllText(rutaMonedasJson, nuevoJson);
            Console.WriteLine($"\t Moneda eliminada correctamente.");
        }
    }
}