using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using SupportManagementCenter.Models;

namespace SupportManagementCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateTicketApiController : ControllerBase
    {
        private readonly SupportManagementCenterDBContext _context;

        public CreateTicketApiController(SupportManagementCenterDBContext context)
        {
            _context = context;
        }

        // GET: api/CreateTicketApi
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CreateTicketApi/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CreateTicketApi
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SupportTicketModel supportTicketModel)
        {
            if (ModelState.IsValid)
            {
                // Add date ticket raised before write to DB
                supportTicketModel.DateRaised = DateTime.Now;

                _context.Add(supportTicketModel);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }

            //return View(supportTicketModel);
            return Ok(supportTicketModel.TicketId);
        }

        // PUT: api/CreateTicketApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
