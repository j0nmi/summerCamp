using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntidadesDTO.Usuarios
{
    public class UsuarioVerDto
    {
        public Guid id { get; set; }

        public string nombrePais { get; set; }
        public string email { get; set; }

        public DateTime? fechaNacimiento { get; set; }
        public string password { get; set; }
    }
}