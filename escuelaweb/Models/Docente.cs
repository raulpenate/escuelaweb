using System;
using System.Collections.Generic;

namespace escuelaweb.Models
{
    public partial class Docente
    {
        public Docente()
        {
            NonimaDocentes = new HashSet<NonimaDocente>();
        }

        public int IdDocente { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Sexo { get; set; }
        public DateTime? FecNac { get; set; }
        public string? Usuario { get; set; }
        public string? Contrasena { get; set; }

        public virtual ICollection<NonimaDocente> NonimaDocentes { get; set; }
    }
}
