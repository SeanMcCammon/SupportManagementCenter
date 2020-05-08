using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using SupportManagementCenter.Models;
using SupportManagementCenter.Services;

namespace SupportManagementCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateTicketApiController : ControllerBase
    {
        private readonly SupportManagementCenterDBContext _context;
        private readonly ITicketServices _ticketServices;

        public CreateTicketApiController(SupportManagementCenterDBContext context,
                                         ITicketServices ticketServices)
        {
            _context = context;
            _ticketServices = ticketServices;
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
            long ticketId = 0; // initiate to 0

            if (ModelState.IsValid)
            {
                // Add date ticket raised before write to DB
                ticketId = _ticketServices.CreateTicket(supportTicketModel);
            }

            //return View(supportTicketModel);
            return Ok(ticketId);
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
