using System;
using System.Collections.Generic;

namespace escuelaweb.Models
{
    public partial class NonimaAlumno
    {
        public int IdNonimnaAlumno { get; set; }
        public int? FkIdAlumno { get; set; }
        public int? FkIdGrado { get; set; }

        public virtual Alumno? FkIdAlumnoNavigation { get; set; }
        public virtual Grado? FkIdGradoNavigation { get; set; }
    }
}
