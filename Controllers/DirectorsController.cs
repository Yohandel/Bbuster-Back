using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {

        private readonly BBusterContext _context;
        public DirectorsController(BBusterContext context) => _context = context;
        [HttpGet]
        public ActionResult<IEnumerable<Director>> GetDirectors()
        {
            return _context.BusterDirectors
            .Include(d => d.Movies)
            .Where(d => d.deleted == false)
            .ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Director> Get(int id)
        {
            var director = _context.BusterDirectors.Find(id);
            if (director == null || director.deleted == true)
            {
                return NotFound("We could not find  this file, it is either deleted or just does not exist");
            }
            return director;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Director director)
        {
            Director directorDB = _context.BusterDirectors.FirstOrDefault(item => item.Name == director.Name);
            if (directorDB != null)
            {
                return Conflict("El nombre especificado ya existe");
            }
            _context.Add(director);
            _context.SaveChanges();

            return CreatedAtAction("GetDirectors", new Director { DId = director.DId }, director);

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var director = _context.BusterDirectors.First(d => d.DId == id);
            director.deleted = !director.deleted;
            _context.SaveChanges();
            return Ok(director);
        }
    }
}