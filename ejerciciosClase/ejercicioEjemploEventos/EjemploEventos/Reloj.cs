namespace EjemploEventos
{
    internal class Reloj
    {
        // Delegado
        public delegate void CambioSegundoDelegado(object reloj, InformacionTiempoEventArgs informacionTiempo);

        // Evento
        public event CambioSegundoDelegado CambioSegundoEvento;
        
        private int segundo;
        private DateTime ultimaEjecucion;
        public Reloj()
        {
            ultimaEjecucion = DateTime.Now;
        }
        public void IniciarReloj()
        {
            DateTime fechaHoraActual = DateTime.Now;
            // Bucle infinito. Otra opción: do {} while (true);
            for (; ; )
            {
                Thread.Sleep(100);
                fechaHoraActual = DateTime.Now;
                // Calcula la diferencia entre 2 fechas
                // Calculamos lo que pasa desde que se inicia hasta que termina de ejecutarse.
                TimeSpan tiempoTranscurrido = fechaHoraActual - ultimaEjecucion;

                // Si han pasado 10 o más segundos...
                if (tiempoTranscurrido.Seconds >= 10)
                    // No debe mostrar nada, pero así vemos qué hace
                    // Console.WriteLine(segundo);
                {
                    // Guardar info tiempo
                    var informacionTiempo = new InformacionTiempoEventArgs(fechaHoraActual.Hour, fechaHoraActual.Minute, fechaHoraActual.Second);

                    // Lanzar el evento
                    if (CambioSegundoEvento != null )
                    {
                        CambioSegundoEvento(this, informacionTiempo);
                    }

                    ultimaEjecucion = fechaHoraActual;

                }
                segundo = fechaHoraActual.Second;
            }

           
        }
    }
}