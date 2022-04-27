using System;
using System.Collections.Generic;

namespace escuelaweb.Models
{
    public partial class Grado
    {
        public Grado()
        {
            NonimaAlumnos = new HashSet<NonimaAlumno>();
            Nota = new HashSet<Notum>();
        }

        public int IdGrado { get; set; }
        public string? Grado1 { get; set; }

        public virtual ICollection<NonimaAlumno> NonimaAlumnos { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
    }
}
