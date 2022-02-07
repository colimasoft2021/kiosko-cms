using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosko.Models
{
    [Keyless]
    public class KColSoftModel
    {
        public string vchKUsuario { get; set; }
    }
}