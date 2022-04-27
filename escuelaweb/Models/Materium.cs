using System;
using System.Collections.Generic;

namespace escuelaweb.Models
{
    public partial class Materium
    {
        public Materium()
        {
            NonimaDocentes = new HashSet<NonimaDocente>();
            Nota = new HashSet<Notum>();
        }

        public int IdMateria { get; set; }
        public string? Materia { get; set; }

        public virtual ICollection<NonimaDocente> NonimaDocentes { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
    }
}
