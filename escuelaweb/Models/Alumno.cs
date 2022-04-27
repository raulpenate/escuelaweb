using System;
using System.Collections.Generic;

namespace escuelaweb.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            NonimaAlumnos = new HashSet<NonimaAlumno>();
            Nota = new HashSet<Notum>();
        }

        public int IdAlumno { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Sexo { get; set; }
        public DateTime? FecNac { get; set; }
        public string? Usuario { get; set; }
        public string? Contrasena { get; set; }

        public virtual ICollection<NonimaAlumno> NonimaAlumnos { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
    }
}
