namespace EjLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ejemploBasico = new EjemploBasico();
            ejemploBasico.Ejecutar();

            var ejemploOperador1 = new EjemploOperador1();
            ejemploOperador1.Ejecutar();
        }
    }
}