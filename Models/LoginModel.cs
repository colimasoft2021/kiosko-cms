using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosko.Models
{
    [Keyless]
    public class LoginModel
    {
        [Required]
        public string vchEmail { get; set; }
        [Required]
        public string vchPass { get; set; }
    }
}
