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
            var relojDigital = new RelojDigital();
             relojDigital.Suscribir(reloj);

            // 2-. Crear reloj digital y nos suscribimos                 Suscriptor
            // PSEUDOCODE:  var relojDigital = new RelojDigital();
            //              relojDigital.Suscribir(reloj);
            // Creamos el objeto y el método suscribir que le pasamos reloj.


            //+ Ejercicio: 
            //  Crear un log o registro que guarde cada 10s la Fecha y la Hora.

            // 3-. Poner en marcha el reloj
            reloj.IniciarReloj();
        }
    }
}