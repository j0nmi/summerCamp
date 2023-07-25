namespace Entidades
{
    public class Vehiculo
    {
        // Al marcar una variable con ? -> Puede ser null
        public int? AnoCompra { get; set; }
        public string? Color { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }

        // Creamos el ctor vacío
        public Vehiculo() { }

        // Constructor con AnoCompra y Color
        public Vehiculo(int anoCompra, string color)
        {
            AnoCompra = anoCompra;
            Color = color;

        }

        // Constructor para vehiculos con Marca y Modelo
        public Vehiculo(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }

        // Ctor para vehiculos con AnoCompra , Color , Marca y Modelo
        public Vehiculo(int anoCompra, string color, string marca, string modelo)
        {
            AnoCompra = anoCompra;
            Color = color;
            Marca = marca;
            Modelo = modelo;
        }
    }
}