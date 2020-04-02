using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BBusterContext _context;

        public UsersController(BBusterContext context) => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _context.BusterUsers;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _context.BusterUsers.Find(id);

            if (user == null || user.deleted == true)
            {
                return NotFound("We could not find  this file, it is either deleted or just does not exist");
            }

            return user;
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return CreatedAtAction("GetUsers", new User { UId = user.UId }, user);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.BusterUsers.First(u => u.UId == id);
            user.deleted = !user.deleted;
            _context.SaveChanges();
            return Ok(user);
        }
    }
}