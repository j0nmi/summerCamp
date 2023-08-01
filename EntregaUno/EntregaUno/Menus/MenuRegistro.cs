using System.Text.RegularExpressions;

namespace EntregaUno.Menus
{
    public class MenuRegistro
    {
        public static void mostrarMenuRegistro()
        {
            // Crear las variables vacías
            string username = string.Empty;
            string email = string.Empty;
            string password = string.Empty;
            string seleccion = string.Empty;

            Console.Clear();

            while (seleccion != "3")
            {
                // Mostrar el menu
                Console.WriteLine($"\n\t MENU REGISTRO\n" +
                                  $"\n\t 1-. Registrarse" +
                                  $"\n\t 2-. Mi cuenta" +
                                  $"\n\t 3-. Salir");

                Console.Write($"\n\t Seleccione una opción (1-2): ");
                seleccion = Console.ReadLine();

                switch (seleccion.ToUpper())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("\n\t REGISTRO DE USUARIO\n");

                        // Pedir nombre de usuario y comprobar que tenga al menos 4 carácteres
                        while (username.Length < 4)
                        {
                            // Pedir nombre de usuario
                            Console.Write($"\t Introduce un nombre de usuario (Debe tener al menos 4 caracteres | S Para salir): ");
                            username = Console.ReadLine();

                            // Si se introduce una S se sale y muestra el menu
                            if (username.ToUpper() == "S")
                            {
                                Console.WriteLine("\n\t Presione cualquier tecla para volver...");
                                Console.ReadKey();
                                mostrarMenuRegistro();
                                break;
                            }
                        }

                        // Pedir direccion de correo electronico
                        while (IsValid(email) != true)
                        {
                            Console.Write($"\t Introduce un email (ejemplo@gmail.com | S Para salir): ");
                            email = Console.ReadLine();
                            if (email.ToUpper() == "S")
                            {
                                break;
                            }
                        }

                        // Pedir contraseña, que tenga más de 5 carácteres
                        while (password.Length <= 5)
                        {
                            Console.Write($"\t Escoge una contraseña (Debe tener al menos 5 caracteres | S Para salir): ");
                            password = Console.ReadLine();
                            if (password.ToUpper() == "S")
                            {
                                break;
                            }
                        }
                        Console.Clear();
                        break;

                    case "2":
                        // Mostrar datos de la cuenta
                        // Se podria agregar una opción para cambiar los datos 
                        Console.Clear();
                        Console.WriteLine($"\n\t MI CUENTA\n" +
                                  $"\n\t 1-. Username: {username}" +
                                  $"\n\t 2-. Email: {email}" +
                                  $"\n\t 3-. Password: {password}");
                        Console.WriteLine("\n\t Presione cualquier tecla para volver...");
                        Console.ReadKey();
                        Console.Clear();
                        break;



                    case "3":
                        // Salir al menu principal
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

        //Comprobar si el email de registro es valido
        private static bool IsValid(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }

    }
}
