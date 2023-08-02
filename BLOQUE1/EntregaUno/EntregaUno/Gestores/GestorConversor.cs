using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EntregaUno.Clases;

namespace EntregaUno.Gestores
{
    public class GestorConversor
    {
        // Ruta del fichero JSON.
        private const string rutaMonedasJson = @"..\..\..\BBDD\monedas.json";
        public static double ResultadoConversor(string codigoMoneda1, string codigoMoneda2, double cantidad)
        {
            double resultado = 0;
            try
            {
                // Guarda el contenido de monedas.json en la variable json
                string json = File.ReadAllText(rutaMonedasJson);

                // Deserializa el json en la lista de monedas
                List<Monedas> listaMonedas = JsonConvert.DeserializeObject<List<Monedas>>(json);


                // Con expresiones lambda
                double valor1 = listaMonedas.Find(moneda => moneda.codigo == codigoMoneda1)?.valorEnDolares ?? 0;
                double valor2 = listaMonedas.Find(moneda => moneda.codigo == codigoMoneda2)?.valorEnDolares ?? 0;

                resultado = cantidad * ((1 / valor1) * valor2);
                Console.WriteLine($"\n\t El cambio de {cantidad} {codigoMoneda1} a {codigoMoneda2} son: {resultado.ToString("0.00")}");

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
            return resultado;
        }
    }
}
