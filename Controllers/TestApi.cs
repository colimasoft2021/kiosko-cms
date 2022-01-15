using Kiosko.Data;
using Kiosko.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kiosko.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApi : ControllerBase
    {
        private readonly ModelosContexto _context;


        public  TestApi(ModelosContexto contexto)
        {
            _context = contexto;
        }

        // GET: api/<TestApi>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modulos>>> GetContactoItems()
        {
            return await _context.Modulos.ToListAsync();
        }

        // GET api/<TestApi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestApi>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
