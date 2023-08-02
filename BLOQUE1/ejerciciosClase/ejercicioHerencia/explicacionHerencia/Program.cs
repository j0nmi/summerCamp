namespace explicacionHerencia
{
    internal class Program
    {

        // Agregar override tostring a empleado, trabajador, administrativo.
        // Mostrar en el resultado si es empleado, admin, trabajador y su nombre.
        // Crear un empleado, un trabajador y un admin.
        // Console.Writeline de empleado.ToString... etc.
        // Agregar una lista.
        // Recorrer la lista y mostrar el tostring de cada empleado.

        static void Main(string[] args)
        {

            // Crear instancia de empleado 
            //aitor.Jefe = jon;


            Object jon = new Empleado("Jon");
            Object aitor = new Trabajador("Aitor");
            Object marcos = new Administrador("Marcos");

            

            //Console.WriteLine(jon.ToString());
            //Console.WriteLine(aitor.ToString());
            //Console.WriteLine(marcos.ToString());

            // Crear ista de tipo generico
            var lista = new List<Object>();
            lista.Add(jon);
            lista.Add(aitor);
            lista.Add(marcos);


            foreach (var Object in lista)
            {
                Console.WriteLine(Object.ToString());
            }
        }
    }
}