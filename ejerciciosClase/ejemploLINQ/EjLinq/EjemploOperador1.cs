namespace EjLinq
{
    internal class EjemploOperador1
    {
        public EjemploOperador1()
        {
        }

        internal void Ejecutar()
        {
            // Lista de empleados
            IEnumerable<Empleado> Empleados = new List<Empleado>()
         {

             new Empleado
             {
                 Nombre = "Jose",
                 Apellidos = "Conde",
                 Ciudad = "Madrid",
                 Telefono = "123456789",
                 Departamento = Departamento.Desarrollo
             },
             new Empleado
             {
                 Nombre = "Luis",
                 Apellidos = "Castillo",
                 Ciudad = "Madrid",
                 Telefono = "423456789",
                 Departamento = Departamento.Soporte
             },
             new Empleado
             {
                 Nombre = "Juan",
                 Apellidos = "Nuñez",
                 Ciudad = "Barcelona",
                 Telefono = "9123456789",
                 Departamento = Departamento.RH
             },
             new Empleado
             {
                 Nombre = "Maria",
                 Apellidos = "Garcia",
                 Ciudad = "Valencia",
                 Telefono = "8123456789",
                 Departamento = Departamento.Admin
             }

          };

            // Define una list consulta LINQ con los empleados definidos anteriormente donde:
            // El Departamento sea Desarrollo o Soporte
            // El apellido empiece por C
            // Devuelve el resultado en orden descendente por nombre en una lista

            List<Empleado> empleadosDesarrolloSoporte = Empleados
                                             .Where(empleado =>
                                                       (empleado.Departamento == Departamento.Desarrollo ||
                                                       empleado.Departamento == Departamento.Soporte)
                                                        && empleado.Apellidos.StartsWith("C")
                                                    )
                                             .OrderByDescending(empleado => empleado.Nombre)
                                             .Select(empleado => empleado)
                                             .ToList();

            List<Empleado> empleadosDesarrolloSoporteConsulta = (from empleado in Empleados
                                                                 where (empleado.Departamento == Departamento.Desarrollo ||
                                                                   empleado.Departamento == Departamento.Soporte)
                                                                   && empleado.Apellidos.StartsWith("C")
                                                                 orderby empleado.Nombre descending
                                                                 select empleado).ToList();


            // Listado de los  telefonos de los empleados de Madrid
            // que contengan en su apellido una "a"
            // ordenado por nombre
            List<Empleado> empleadosMadrid = Empleados
                                             .Where(empleado =>
                                                       (empleado.Ciudad == "Madrid" 
                                                       && empleado.Nombre.Contains("a")
                                                       || empleado.Nombre.Contains("A")
                                                    ))
                                             .OrderBy(empleado => empleado.Nombre)
                                             .Select(empleado => empleado)
                                             .ToList();


            List<Empleado> empleadosMadridConsulta = (from empleado in Empleados
                                                                 where (empleado.Ciudad == "Madrid") && empleado.Apellidos.Contains("a") || empleado.Apellidos.Contains("A")
                                                                 orderby empleado.Nombre ascending
                                                                 select empleado).ToList();






        }
    }
}