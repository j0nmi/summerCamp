namespace Entidades
{
    // public - Visibe en todo el proyecto
    // private - No es visible
    // protected -  Solo es visible por la clase o derivada de esta
    // internal -  Solo del mismo ensamblado
    public class Empleado
    {
        // ctor para el constructor
        public Empleado()
        {

        }

        public enum Nivel
        {
            normal,
            bueno,
            excelente
        }

            private Nivel _nivel;

        public void FijarNivel(Nivel nivel)
        {
            this._nivel = nivel;
        }

        public Empleado(string nombre, double salario, DateTime fechaAlta, bool alta)
        {
            Nombre = nombre;
            Salario = salario;
            FechaAlta = fechaAlta;
            Alta = alta;
        }

        // prop y tabular para definir mas rapido
        public string Nombre { get; set; }
        public double Salario { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public bool Alta { get; set; }

        public void CalcularAumentoSalario()
        {
            // throw new NotImplementedException();
        }
    }
}
