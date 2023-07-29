using System;

namespace EntregaUno.Menus
{
    public class MenuLogin
    {
        public static void mostrarMenuLogin()
        {
            Console.Clear();

            string Nombre = "Juan";
            string Email = "ejemplo@gmail.com";
            string Contrasena = "123456";

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
                        string Usuario = Console.ReadLine();
                        Console.Write("\t Introduce tu contraseña: ");
                        string Password = Console.ReadLine();

                        if ((Usuario.ToUpper() == Nombre.ToUpper() || Usuario.ToUpper() == Email.ToUpper()) && Password == Contrasena)
                        {
                            Continuar = true;

                            Nombre = Usuario;
                            Contrasena = Password;
                            Console.WriteLine("\t Inicio de sesión exitoso.");
                        }
                        else
                        {
                            Console.WriteLine("\t Credenciales incorrectas. Intente nuevamente.");
                        }
                        break;



                    case 2:
                        Console.WriteLine("\n\t Presione cualquier tecla para salir...");
                        Console.ReadKey();
                        MenuPrincipal.mostrarMenuPrincipal();
                        break;

                    default:
                        Console.WriteLine("\t Opción no válida. Intente nuevamente.");
                        break;
                }
            }

            // Se puede crear una opcion de recuperar contraseña 

            Console.WriteLine($"\t Bienvenido, {Nombre}!");
        }


    }
}




