using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosko.Models
{
    public class Modulos
    {
        [Key]
        public int id { get; set; }
        public string titulo { get; set; }
        public bool acceso_directo { get; set; }
        public int orden { get; set; }
    }
}
