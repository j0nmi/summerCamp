namespace EjemploEventos
{
    internal class Program
    {
        // Crear delegado
        // Crear evento
        // Crear método
        static void Main(string[] args)
        {
            // 1-. Crear instancia del reloj interno                     Publicador
            var reloj = new Reloj();

            // 2-. Crear reloj digital y nos suscribimos                 Suscriptor

            // 3-. Poner en marcha el reloj
            reloj.IniciarReloj();
        }
    }
}