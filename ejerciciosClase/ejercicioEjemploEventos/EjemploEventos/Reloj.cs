namespace EjemploEventos
{
    internal class Reloj
    {
        // Delegado
        public delegate void CambioSegundoDelegado(object reloj, InformacionTiempoEventArg informacionTiempo);

        // Evento
        public event CambioSegundoDelegado CamioSegundoEvento;
        public Reloj()
        {
        }
    }
}