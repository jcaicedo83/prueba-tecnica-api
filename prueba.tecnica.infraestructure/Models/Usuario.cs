using System;
using System.Collections.Generic;

namespace prueba.tecnica.infraestructure.Models
{
    public partial class Usuario
    {
        public string? Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Sexo { get; set; }
        public int IdUsuario { get; set; }
    }
}
