using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace escuelaweb.Models
{
    public partial class Notum
    {
        public int IdNota { get; set; }
        
        public int? FkIdAlumno { get; set; }
        
        public int? FkIdMateria { get; set; }
        
        public int? FkIdGrado { get; set; }
        [Display(Name = "Nota 1")]
        public decimal? Nota1 { get; set; }
        [Display(Name = "Nota 2")]
        public decimal? Nota2 { get; set; }
        [Display(Name = "Nota 3")]
        public decimal? Nota3 { get; set; }
        [Display(Name = "Promedio")]
        public decimal? NotaFinal { get; set; }

        [Display(Name = "Alumno")]
        public virtual Alumno? FkIdAlumnoNavigation { get; set; }
        [Display(Name = "Grado")]
        public virtual Grado? FkIdGradoNavigation { get; set; }
        [Display(Name = "Materia")]
        public virtual Materium? FkIdMateriaNavigation { get; set; }
    }
}
