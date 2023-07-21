using Entidades;

namespace ejemploClasesSolucion
{
    internal class Program
    {
        // Calcular salario de empleados
        static void Main(string[] args)
        {

            // Crear y asignar propiedades mediante la instancia

            // Forma 1
            var jose = new Empleado();
            jose.Nombre = "Jose";
            jose.FechaAlta = new DateTime(2021, 01, 10);
            jose.Salario = 20000;
            jose.Alta = true;
            jose.FijarNivel(Empleado.Nivel.excelente);

            // Forma 2
            var maria = new Empleado()
            {
                Nombre = "Maria",
                FechaAlta = new DateTime(2022, 03, 01),
                Salario = 25000,
                Alta = true,
            };

            // Forma 3
            var juan = new Empleado("Juan", 20000, new DateTime(2022, 03, 15), true,);


            // Crear lista
            var numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            numeros.Add(9);

            // Lista de tipo generico
            var lista = new List<Empleado>();
            lista.Add(jose);
            lista.Add(maria);   
            lista.Add(juan);    


            foreach (var empleado in lista) {
                empleado.CalcularAumentoSalario();
            }

        }
    }
}