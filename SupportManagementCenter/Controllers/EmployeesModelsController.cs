using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportManagementCenter.Models;

namespace SupportManagementCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesModelsController : ControllerBase
    {
        private readonly SupportManagementCenterDBContext _context;

        public EmployeesModelsController(SupportManagementCenterDBContext context)
        {
            _context = context;
        }

        // GET: api/EmployeesModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeesModel>>> GetAssignedEmployee()
        {
            return await _context.AssignedEmployee.ToListAsync();
        }

        // GET: api/EmployeesModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeesModel>> GetEmployeesModel(long id)
        {
            var employeesModel = await _context.AssignedEmployee.FindAsync(id);

            if (employeesModel == null)
            {
                return NotFound();
            }

            return employeesModel;
        }

        // PUT: api/EmployeesModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeesModel(long id, EmployeesModel employeesModel)
        {
            if (id != employeesModel.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employeesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeesModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeesModel>> PostEmployeesModel(EmployeesModel employeesModel)
        {
            _context.AssignedEmployee.Add(employeesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeesModel", new { id = employeesModel.EmployeeId }, employeesModel);
        }

        // DELETE: api/EmployeesModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeesModel>> DeleteEmployeesModel(long id)
        {
            var employeesModel = await _context.AssignedEmployee.FindAsync(id);
            if (employeesModel == null)
            {
                return NotFound();
            }

            _context.AssignedEmployee.Remove(employeesModel);
            await _context.SaveChangesAsync();

            return employeesModel;
        }

        private bool EmployeesModelExists(long id)
        {
            return _context.AssignedEmployee.Any(e => e.EmployeeId == id);
        }
    }
}
