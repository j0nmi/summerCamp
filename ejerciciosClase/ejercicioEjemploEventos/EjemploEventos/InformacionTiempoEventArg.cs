namespace EjemploEventos
{

    public class InformacionTiempoEventArg
    {
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public int Segundo { get; set; }
        public InformacionTiempoEventArg() { }
        public InformacionTiempoEventArg(int hora, int minuto, int segundo)
        {
            Hora = hora;
            Minuto = minuto;
            Segundo = segundo;
        }
    }
}