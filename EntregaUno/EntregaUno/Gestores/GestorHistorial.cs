using EntregaUno.Clases;
using Newtonsoft.Json;

namespace EntregaUno.Gestores
{
    public class GestorHistorial
    {
        // Ruta del fichero JSON.
        private const string rutaHistorialJson = @"..\..\..\BBDD\historial.json";

        public static void ListarHistorial()
        {
            try
            {
                // Guarda el contenido de historial.json en la variable json
                string json = File.ReadAllText(rutaHistorialJson);

                // Deserializa el json en la lista de registros de historial
                List<HistorialConversiones> listaHistorial = JsonConvert.DeserializeObject<List<HistorialConversiones>>(json);

                foreach (HistorialConversiones registro in listaHistorial)
                {
                    double cantidad = registro.Cantidad;
                    string monedaOrigen = registro.MonedaOrigen;
                    string monedaDestino = registro.MonedaDestino;
                    decimal resultadoConversion = registro.ResultadoConversion;
                    string fechaConversion = registro.FechaConversion;

                    // Muestra el registro
                    Console.WriteLine($"\t CONVERSION | Fecha: {fechaConversion} | El cambio de {cantidad} {monedaOrigen} a {monedaDestino} es: {resultadoConversion}");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"\t ERROR | No se encontró el archivo {rutaHistorialJson}. Detalles: {ex.Message}");
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

        public static void CrearRegistroHistorial(HistorialConversiones nuevoRegistro)
        {
            try
            {
                string json = File.ReadAllText(rutaHistorialJson);

                List<HistorialConversiones> listaHistorial = JsonConvert.DeserializeObject<List<HistorialConversiones>>(json);
                listaHistorial.Add(nuevoRegistro);

                string nuevoJson = JsonConvert.SerializeObject(listaHistorial, Formatting.Indented);

                File.WriteAllText(rutaHistorialJson, nuevoJson);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"\t ERROR | No se encontró el archivo {rutaHistorialJson}. Detalles: {ex.Message}");
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
    }
}
