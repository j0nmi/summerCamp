using System.Text.RegularExpressions;

namespace EntregaUno.Menus
{
    public class MenuLogin
    {
        public static void mostrarMenuLogin()
        {
            Console.Clear();

            string Nombre = "Juan";
            string Email = "ejemplo@gmail.com";
            string Password = "123456";

            bool Continuar = false;

            while (!Continuar)
            {
                Console.WriteLine($"\n\t SISTEMA DE LOGIN\n");
                Console.WriteLine("\t 1-. Iniciar sesión");
                Console.WriteLine("\t 2-. Salir");
                Console.Write($"\n\t Seleccione una opción (1-2): ");

                int opcion;
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("\t Opción no válida. Intente nuevamente.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("\t Ingrese usuario o correo electronico: ");
                        string UsuarioCorreo = Console.ReadLine();


                        if (UsuarioCorreo == Nombre || EsCorreoValido(UsuarioCorreo))
                        {
                            // Pedir al usuario que ingrese la contraseña
                            Console.Write("\t Introduce la contraseña: ");
                            string contrasena = Console.ReadLine();

                            // Realizar la validación del inicio de sesión
                            if (ValidarCredenciales(UsuarioCorreo, contrasena, Nombre, Email, Password))
                            {
                                Console.WriteLine($"Inicio de sesión exitoso. ¡Bienvenido! {Nombre}");
                                Console.WriteLine("\n\t Presione cualquier tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                                MenuRegistro.mostrarMenuRegistro();
                            }
                            else
                            {
                                Console.WriteLine("Correo electrónico o contraseña incorrectos. Inténtalo nuevamente.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("El formato del correo electrónico o usuarion no es válido. Inténtalo nuevamente.");
                        }
                        break;
                        Console.Clear();


                    case 2:
                        Console.WriteLine("\n\t Presione cualquier tecla para salir...");
                        Console.ReadKey();
                        MenuPrincipal.mostrarMenuPrincipal();
                        break;

                    default:
                        Console.WriteLine("\t Opción no válida. Intente nuevamente.");
                        break;
                        Console.Clear();
                }
            }

            // Se puede crear una opcion de recuperar contraseña 


        }

        public static bool ValidarCredenciales(string UsuarioCorreo, string contrasena, string Nombre, string Email, string Password)
        {
            return UsuarioCorreo == Nombre || UsuarioCorreo == Email && contrasena == Password;
        }

        public static bool EsCorreoValido(string correo)
        {
            // Expresión regular para validar el formato del correo electrónico
            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Crear un objeto Regex con el patrón
            Regex regex = new Regex(patron);

            // Comprobar si el correo coincide con el patrón
            return regex.IsMatch(correo);
        }

    }
}




