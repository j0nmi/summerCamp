namespace EjemploEventos
{
    internal class RelojDigital
    {
        public RelojDigital()
        {
        }

        internal void Suscribir(Reloj reloj)
        {
            reloj.CambioSegundoEvento += Reloj_CambioSegundoEvento;
        }

        private void Reloj_CambioSegundoEvento(object reloj, InformacionTiempoEventArgs e)
        {
           // Console.WriteLine($" La hora actual es: {e.Hora.ToString()}:{e.Minuto.ToString()}:{e.Segundo.ToString()}.");
        }
    }
}