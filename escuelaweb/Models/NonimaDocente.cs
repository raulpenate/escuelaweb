using System;
using System.Collections.Generic;

namespace escuelaweb.Models
{
    public partial class NonimaDocente
    {
        public int IdNonimnaDocente { get; set; }
        public int? FkIdDocente { get; set; }
        public int? FkIdGrado { get; set; }
        public int? FkIdMateria { get; set; }
    }
}
