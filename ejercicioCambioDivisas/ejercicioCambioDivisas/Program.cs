namespace ejercicioCambioDivisas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"\n\tBienvenido al conversor de monedas");
            Console.WriteLine($"\t----------------------------------------------");

            // Pedir la moneda origen
            Console.Write($"\tIntroduce la moneda origen (EUR, USD, GBP): ");
            string monedaOrigen = Console.ReadLine().ToUpper();

            // Pedir la moneda destino
            Console.Write($"\tIntroduce la moneda destino (EUR, USD, GBP): ");
            string monedaDestino = Console.ReadLine().ToUpper();

            // Pedir el importe
            Console.Write($"\tIntroduce el importe: ");
            double importe = Convert.ToDouble(Console.ReadLine());

            double resultado = 0; // Vaciamos el resultado

            if (monedaOrigen == "EUR")
            {
                if (monedaDestino == "USD")
                {
                    resultado = importe * 1.12; // Tasa de cambio EUR-USD
                }
                else if (monedaDestino == "GBP")
                {
                    resultado = importe * 0.87; // Tasa de cambio EUR-GBP
                }
                else
                {
                    resultado = importe; // Si es de EUR-EUR
                }
            }
            else if (monedaOrigen == "USD")
            {
                if (monedaDestino == "EUR")
                {
                    resultado = importe / 0.89;
                }
                else if (monedaDestino == "GBP")
                {
                    resultado = importe * 0.77;
                }
                else
                {
                    resultado = importe;
                }
            }
            else if (monedaOrigen == "GBP")
            {
                if (monedaDestino == "EUR")
                {
                    resultado = importe / 0.85;
                }
                else if (monedaDestino == "USD")
                {
                    resultado = importe / 0.72;
                }
                else
                {
                    resultado = importe;
                }
            }
            else
            {
                Console.WriteLine($"\nMoneda origen no válida");
                return;
            }

                // Mostrar el resultado
                Console.WriteLine($"\t----------------------------------------------");
                Console.WriteLine($"\tResultado: {resultado} {monedaDestino}");

            }
        }
    }