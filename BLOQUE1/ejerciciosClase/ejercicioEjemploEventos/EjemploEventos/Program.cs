namespace EjemploEventos
{
    internal class Program
    {
        // Crear delegado
        // Crear evento
        // Crear método

        //+ Ejercicio: 
        //+ Crear un log o registro que guarde cada 10s la Fecha y la Hora.
        static void Main(string[] args)
        {
            // 1-. Crear instancia del reloj interno                     Publicador
            var reloj = new Reloj();
            var relojDigital = new RelojDigital();
            var log = new Registro();

            // 2-. Crear reloj digital y nos suscribimos                 Suscriptor
            relojDigital.Suscribir(reloj);
            log.Suscribir(reloj);

            // 3-. Poner en marcha el reloj
            reloj.IniciarReloj();

            
            
            

        }
    }
}