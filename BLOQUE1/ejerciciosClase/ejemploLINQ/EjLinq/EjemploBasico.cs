namespace EjLinq
{
    internal class EjemploBasico
    {
        public EjemploBasico()
        {
        }

        public void Ejecutar()
        {
            string[] niveles = { "Básico", "Intermedio", "Avanzado" };
            int nc = niveles.Count();

            // Seleciona los niveles cuya longitud en caracteres es > 6
            var listaConsultaForeach = new List<string>();
            foreach (string nivel in niveles)
            {
                if (nivel.Length > 6)
                {
                    listaConsultaForeach.Add(nivel);
                }
            }

            // Sintaxis con SQL
            // Ordenado por nombre de nivel
            var consultaLinq = from nivel in niveles
                               where nivel.Length > 6
                               orderby nivel
                               select nivel;

            // Obtener resultados
            List<string> listaResultado = consultaLinq.ToList();

            // Sintaxis de Metodos
            // 1-. Preparación
            var consultaLinqMetodos = niveles.Where(nivel => nivel.Length > 6)
                                             .OrderBy(nivel => nivel)
                                             .Select(nivel => nivel);

            // 2-. Resultados
            List<string> listaResultadoLinqMetodos = consultaLinqMetodos.ToList();
        }
    }
}