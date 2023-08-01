using EntregaUno.Clases;
using Newtonsoft.Json;

namespace EntregaUno.Gestores
{
    public class GestorMonedas
    {
        // Ruta del fichero JSON.
        private const string rutaMonedasJson = @"..\..\..\BBDD\monedas.json";

        public static void ListarMonedas()
        {
            try
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
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"\t ERROR | No se encontró el archivo {rutaMonedasJson}. Detalles: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\t ERROR | Error al deserializar el archivo JSON. Detalles: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t ERROR | Error inesperado: {ex.Message}");
            }
        }

        public static void CrearMonedas()
        {
            try
            {
                // Pedimos valores
                string nombreNuevaMoneda;
                Console.Write($"\t Nombre de la nueva moneda: ");
                while (string.IsNullOrEmpty(nombreNuevaMoneda = Console.ReadLine()))
                {
                    Console.Write("\t ERROR | Nombre de moneda inválido. Introduce un nombre de moneda válido: ");
                }
                string codigoNuevaMoneda;
                Console.Write("\t Codigo de la nueva moneda (debe tener 3 caracteres): ");
                while (true)
                {
                    codigoNuevaMoneda = Console.ReadLine();

                    if (codigoNuevaMoneda.Length == 3 && codigoNuevaMoneda.All(char.IsLetter))
                    {
                        // La entrada es válida, es un texto de 3 caracteres.
                        break;
                    }
                    else
                    {
                        Console.Write("\t ERROR | Código de moneda inválido. Introduce un código de moneda válido (3 caracteres de texto): ");
                    }
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
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"\t ERROR | No se encontró el archivo {rutaMonedasJson}. Detalles: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\t ERROR | Error al deserializar el archivo JSON. Detalles: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t ERROR | Error inesperado: {ex.Message}");
            }
        }

        public static void EditarMoneda()
        {
            try
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
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"\t ERROR | No se encontró el archivo {rutaMonedasJson}. Detalles: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\t ERROR | Error al deserializar el archivo JSON. Detalles: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t ERROR | Error inesperado: {ex.Message}");
            }
        }

        public static void EliminarMoneda()
        {
            try
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
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"\t ERROR | No se encontró el archivo {rutaMonedasJson}. Detalles: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\t ERROR | Error al deserializar el archivo JSON. Detalles: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t ERROR | Error inesperado: {ex.Message}");
            }

        }

        // Método para verificar si la moneda existe en monedas.json
        public static bool ExisteMoneda(string moneda)
        {
            string json = File.ReadAllText(rutaMonedasJson);
            List<Monedas> listaMonedas = JsonConvert.DeserializeObject<List<Monedas>>(json);

            return listaMonedas.Any(monedaObj => monedaObj.codigo.StartsWith(moneda));
        }
    }
}