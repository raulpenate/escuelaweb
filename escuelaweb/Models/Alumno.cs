using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace escuelaweb.Models
{
    public partial class Alumno
    {

        public int IdAlumno { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Sexo { get; set; }
        [Display(Name = "Fecha Nacimiento")]
        public DateTime? FecNac { get; set; }
        public string? Usuario { get; set; }
        public string? Contrasena { get; set; }

    }
}
