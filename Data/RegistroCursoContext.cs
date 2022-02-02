using Kiosko.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosko.Data
{
    public class RegistroCursoContext : DbContext
    {
        public RegistroCursoContext(DbContextOptions<RegistroCursoContext> options) : base(options)
        {

        }
        public DbSet<RegistroCursoModel> RegistroCursoItems { get; set; }
    }
}
