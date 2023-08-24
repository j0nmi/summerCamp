using Microsoft.AspNetCore.Identity;

namespace EjemploAPIAutenticada.Seguridad
{
    public class Usuario : IdentityUser
    {
        public int Id { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }

    public class Pais
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
