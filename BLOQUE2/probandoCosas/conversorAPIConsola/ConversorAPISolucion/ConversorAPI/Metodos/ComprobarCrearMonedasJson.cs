using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorAPI.Metodos
{
    public class ComprobarCrearMonedasJson
    {
        public ComprobarCrearMonedasJson()
        {
            
        }
        public static void ComprobarCrearMonedas()
        {
            // Obtener la ruta actual del directorio
            string rutaActual = Directory.GetCurrentDirectory();

            // Cambiar la ruta del directorio actual a 3 niveles más arriba
            for (int i = 0; i < 3; i++)
            {
                rutaActual = Path.GetDirectoryName(rutaActual);
            }

            // Comprobar si existe la carpeta BBDD y si no existe, crearla
            string rutaBBDD = Path.Combine(rutaActual, "BBDD");
            if (!Directory.Exists(rutaBBDD))
            {
                Directory.CreateDirectory(rutaBBDD);
            }

            // Comprobar si existe el fichero monedas.json dentro de la carpeta BBDD
            string rutaFicheroMonedas = Path.Combine(rutaBBDD, "monedas.json");
            if (!File.Exists(rutaFicheroMonedas))
            {
                // Si no existe el archivo, creamos un archivo con una lista vacía
                File.WriteAllText(rutaFicheroMonedas, "[]");
            }

            Console.WriteLine("El archivo monedas.json se ha creado o ya existe en la carpeta BBDD.");
        }
    }
}
