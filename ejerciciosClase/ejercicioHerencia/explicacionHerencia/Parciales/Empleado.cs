using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace explicacionHerencia
{
    public partial class Empleado
    {
        public string? Telefono { get; set; }
        public Empleado Jefe { get; set;}
    }
}
