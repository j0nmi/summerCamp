namespace EjemploEventos
{
    internal class Registro
    {
        public Registro()
        {
        }

        internal void Suscribir(Reloj reloj)
        {
            reloj.CambioSegundoEvento += Reloj_CambioSegundoEvento;
        }
        private void Reloj_CambioSegundoEvento(object reloj, InformacionTiempoEventArgs e)
        {
            Console.WriteLine($" Fecha: {DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}");
            Console.WriteLine($" Hora: {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}\n");
        }
    }
}