using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntidadesDTO.Usuarios
{
    public class UsuarioActualizarDto
    {
        public Guid idPais { get; set; }
        public string email { get; set; }

        public DateTime? fechaNacimiento { get; set; }
        public string password { get; set; }
    }
}