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
    public class InvoicesController : ControllerBase
    {
        private readonly BBusterContext _context;

        public InvoicesController(BBusterContext context) => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Invoice>> GetInvoices()
        {
            return _context.BusterInvoice;
        }

        [HttpGet("{id}")]
        public ActionResult<Invoice> GetInvoice(int id)
        {
            var invoice = _context.BusterInvoice.Find(id);
            if (invoice == null || invoice.deleted == true)
            {
                return NotFound("We could not find  this file, it is either deleted or just does not exist");

            }

            return invoice;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Invoice invoice)
        {
            _context.Add(invoice);
            _context.SaveChanges();
            return CreatedAtAction("GetInvoices", new Invoice { Id = invoice.Id }, invoice);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var invoice = _context.BusterInvoice.First(i => i.Id == id);

            invoice.deleted = !invoice.deleted;
            _context.SaveChanges();
            return Ok(invoice);
        }
    }
}