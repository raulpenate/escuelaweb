using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace escuelaweb.Models
{
    public partial class Notum
    {
        public int IdNota { get; set; }
        [Display(Name = "Alumno")]
        public int? FkIdAlumno { get; set; }
        [Display(Name = "Docente")]
        public int? FkIdDocente { get; set; }
        [Display(Name = "Materia")]
        public int? FkIdMateria { get; set; }
        [Display(Name = "Grado")]
        public int? FkIdGrado { get; set; }
        public decimal? Calificacion { get; set; }
        public int? Trimestre { get; set; }

    }
}
