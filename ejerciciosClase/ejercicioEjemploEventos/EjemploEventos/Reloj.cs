namespace EjemploEventos
{
    internal class Reloj
    {
        // Delegado
        public delegate void CambioSegundoDelegado(object reloj, InformacionTiempoEventArgs informacionTiempo);

        // Evento
        public event CambioSegundoDelegado CambioSegundoEvento;
        public Reloj()
        {
        }

        private int segundo;
        public void IniciarReloj()
        {
            DateTime fechaHoraActual;
            // Bucle infinito. Otra opción: while (true) { };
            for (; ; )
            {
                Thread.Sleep(100);
                fechaHoraActual = DateTime.Now;
                if ( fechaHoraActual.Second != segundo )
                {
                    // Guardar info tiempo
                    var informacionTiempo = new InformacionTiempoEventArgs(fechaHoraActual.Hour, fechaHoraActual.Minute, fechaHoraActual.Second);

                    // Lanzar el evento
                    if (CambioSegundoEvento != null )
                    {
                        CambioSegundoEvento(this, informacionTiempo);
                    }

                }
                segundo = fechaHoraActual.Second;
            }

           
        }
    }
}