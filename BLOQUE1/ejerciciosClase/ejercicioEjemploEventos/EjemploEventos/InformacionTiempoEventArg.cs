namespace EjemploEventos
{

    public class InformacionTiempoEventArgs
    {
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public int Segundo { get; set; }
        public InformacionTiempoEventArgs() { }
        public InformacionTiempoEventArgs(int hora, int minuto, int segundo)
        {
            Hora = hora;
            Minuto = minuto;
            Segundo = segundo;
        }
    }
}