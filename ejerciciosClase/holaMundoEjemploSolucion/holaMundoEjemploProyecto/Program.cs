namespace holaMundoEjemploProyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //? Para k admita valores nulos
            //tipoDato nombreVar = valor
            string? nombre = "Jon".ToUpper();
            nombre = nombre.ToUpper();
            nombre = null;

            try
            {
                Console.WriteLine("Hola Mundo! , ".ToUpper() + nombre?.ToUpper());
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR!");
                throw;
            }
        }
    }
}