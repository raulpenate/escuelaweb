using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace escuelaweb.Models
{
    public partial class Grado
    {
        public int IdGrado { get; set; }
        [Display(Name = "Grado")]
        public string? Grado1 { get; set; }
    }
}
