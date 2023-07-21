using System.Linq.Expressions;
namespace explicacionHerencia
{
    internal class Program
    {

        // Crear una excepción personalizada ErrorBaseDatos
        // Almacena la fecha y hora de la excp y el msg
        // Ocurre al pedir la plaza de parking de un administrador

        // Identificar mediante reflexión los diferentes tipos de empleado
        // a) Es trabajador: muestra el turno
        // b) Es administrador y tiene plaza de parking: mostrar plaza de parking


        static void Main(string[] args)
        {

            // Crear instancia de empleado 
            //aitor.Jefe = jon;


            Empleado jon = new Empleado("Jon");
            Empleado aitor = new Trabajador("Aitor", "Mañana");
            Empleado jose = new Externo("Jose", new Empresa("Gamesa", 31621));
            Empleado marcos = new Administrador("Marcos", true);

            // Crear ista de tipo generico
            var lista = new List<Empleado>();
            lista.Add(jon);
            lista.Add(aitor);
            lista.Add(jose);
            lista.Add(marcos);

            foreach (var empleado in lista)
            {
                if (empleado.Nombre.StartsWith("J"))
                {
                    empleado.CalculoVacaciones();
                }
                Console.WriteLine(empleado.ToString());
            }

            try
            {
                if (marcos.TieneParking)
                {
                    Console.WriteLine(marcos.PlazaParking());
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
        }
    }
}