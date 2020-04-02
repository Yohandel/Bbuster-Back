using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiRestTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRestTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly BBusterContext _context;

        public MoviesController(BBusterContext context) => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            return _context.BusterMovies
            .Include(m => m.Category)
            .Include(m => m.director)
            .Where(m => m.deleted == false)
            .ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            var movie = _context.BusterMovies.Find(id);

            if (movie == null || movie.deleted == true)
            {
                return NotFound("We could not find  this file, it is either deleted or just does not exist");
            }

            return movie;
        }

        [HttpPost]
        public IActionResult Post(int categoryId, [FromBody] Movie movie)
        {
            var category = _context.BusterCategories.Find(categoryId);
            _context.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction("GetMovies", new Movie { MovieId = movie.MovieId }, movie);

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _context.BusterMovies.First(m => m.MovieId == id);
            movie.deleted = !movie.deleted;
            _context.SaveChanges();
            return Ok(movie);
        }
    }
}