﻿using System.ComponentModel.DataAnnotations;

namespace Entidades.Entities
{
    public class Pais
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        public string bandera { get; set; }

        [Required]
        public string nombre { get; set; }

        public Pais(string nombre, string bandera)
        {
            this.bandera = bandera;
            this.nombre = nombre;
        }
    }
}