namespace EntregaUno.Menus
{
    public class MenuPrincipal
    {
        public static void mostrarMenuPrincipal()
        {
            Console.Clear();

            // Declaramos la variable seleccion y la vacíamos
            string seleccion = string.Empty;

            // Mientras que la seleccion no sea 4 (SALIR)
            while (seleccion != "5")
            {
                // Se muestra el menu solo una vez, al inicio del bucle
                Console.WriteLine($"\n\t MENU PRINCIPAL\n" +
                                  $"\n\t 1-. Monedas" +
                                  $"\n\t 2-. Conversor" +
                                  $"\n\t 3-. Registro" +
                                  $"\n\t 4-. Login" +
                                  $"\n\t 5-. Salir");

                Console.Write($"\n\t Seleccione una opción (1-4): ");
                seleccion = Console.ReadLine();

                switch (seleccion)
                {
                    case "1":
                        MenuMonedas.mostrarMenuMonedas();
                        break;
                    case "2":
                        MenuConversor.mostrarMenuConversor();
                        break;
                    case "3":
                        MenuRegistro.mostrarMenuRegistro();
                        break;
                    case "4":
                        MenuLogin.mostrarMenuLogin();
                        break;
                    case "5":
                        Console.WriteLine("\n\t Presione cualquier tecla para salir...");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }

        }
    }
}
