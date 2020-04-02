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
    public class CategoriesController : ControllerBase
    {
        private readonly BBusterContext _context;

        public CategoriesController(BBusterContext context) => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return _context.BusterCategories
            .Include(c => c.Movies)
            .Where(c => c.deleted == false)
            .ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _context.BusterCategories.Find(id);
            if (category == null || category.deleted == true)
            {
                return NotFound("We could not find  this file, it is either deleted or just does not exist");
            }
            return category;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            _context.Add(category);
            _context.SaveChanges();

            return CreatedAtAction("GetCategories", new Category { CategoryId = category.CategoryId }, category);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.BusterCategories.First(d => d.CategoryId == id);
            category.deleted = !category.deleted;
            _context.SaveChanges();
            return Ok(category);
        }
    }
}