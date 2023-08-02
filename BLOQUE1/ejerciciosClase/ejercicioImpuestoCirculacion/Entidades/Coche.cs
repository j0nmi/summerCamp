namespace Entidades
{
    public class Coche
    {
        public Coche()
        {
        }

        public Coche(string nombre, double valorBase, Etiqueta etiqueta)
        {
            Nombre = nombre;
            ValorBase = valorBase;
            EtiquetaContaminacion = etiqueta;
        }

        public enum Etiqueta
        {
            EtiquetaSIN,
            EtiquetaB,
            EtiquetaC,
            EtiquetaECO,
            EtiquetaCERO,
        }

        private Etiqueta etiqueta;

        public void FijarEtiqueta(Etiqueta etiqueta)
        {
            this.etiqueta = etiqueta;
        }


        public string Nombre { get; set; }
        public double ValorBase { get; set; }
        public int AnoMatriculacion { get; set; }
        public Etiqueta EtiquetaContaminacion { get; set; }

        public double CalcularImpuestoCirculacion()
        {
            double impuesto = ValorBase;
            int antiguedad = DateTime.Now.Year - AnoMatriculacion;
            impuesto += impuesto * (antiguedad * 0.01);

            switch (EtiquetaContaminacion)
            {
                case Etiqueta.EtiquetaSIN:
                    impuesto += impuesto * 0.25;
                    break;
                case Etiqueta.EtiquetaB:
                    impuesto += impuesto * 0.15;
                    break;
                case Etiqueta.EtiquetaC:
                    impuesto += impuesto * 0.10;
                    break;
                case Etiqueta.EtiquetaECO:
                    impuesto += impuesto * 0.05;
                    break;
                case Etiqueta.EtiquetaCERO:
                    // No suma
                    break;
            }

            return impuesto;
        }
    }
}
