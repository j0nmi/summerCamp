using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entities
{
    public class Usuario
    {
        [Key]
        public Guid id { get; set; }

        
        public Guid? idPais { get; set; }

        [ForeignKey("idPais")]
        public Pais? pais { get; set; }
        [Required]
        public string email { get; set; }

        public DateTime? fechaNacimiento { get; set; }

        [Required]
        public string password { get; set; }



        public Usuario(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}