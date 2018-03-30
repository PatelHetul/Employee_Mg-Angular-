using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_Mg_Angular.Models;

namespace Employee_Mg_Angular.Controllers
{
    //[Produces("application/json")]
    //[Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        [Route("api/Employee/Index")]
        public IEnumerable<EmployeeMaster> GetEmployeeMaster()
        {
              var emplist = _context.EmployeeMaster.Where(e => e.IsDelete == 0 && e.DepartmentMaster.IsDelete == 0).ToList();
           
            return emplist;
        }

        // GET: api/Employee/5
        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public async Task<IActionResult> GetEmployeeMaster([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeMaster = await _context.EmployeeMaster.SingleOrDefaultAsync(m => m.Employee_Id == id);

            if (employeeMaster == null)
            {
                return NotFound();
            }

            return Ok(employeeMaster);
        }

        // PUT: api/Employee/5
        [HttpPut]
        [Route("api/Employee/Edit")]
        public async Task<IActionResult> PutEmployeeMaster([FromRoute] int id, [FromBody] EmployeeMaster employeeMaster)
        {

            if (_context.EmployeeMaster.Any(name => name.Email.Equals(employeeMaster.Email) && name.Employee_Id != employeeMaster.Employee_Id && name.IsDelete == 0))
            {
                ModelState.AddModelError(string.Empty, "Employee is already exists");
                return BadRequest(ModelState);
            }
            employeeMaster.IsDelete = 0;
            _context.Entry(employeeMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeMasterExists(id))
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


        // POST: api/Employee
        [HttpPost]
        [Route("api/Employee/Create")]
        public async Task<IActionResult> PostEmployeeMaster([FromBody] EmployeeMaster employeeMaster)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (_context.EmployeeMaster.Any(name => name.Email.Equals(employeeMaster.Email) && name.IsDelete == 0))
            {
                ModelState.AddModelError(string.Empty, "Employee is already exists");
                return BadRequest(ModelState);
            }
            employeeMaster.IsDelete = 0;
            _context.EmployeeMaster.Add(employeeMaster);
            await _context.SaveChangesAsync();
            return NoContent();
            // return CreatedAtAction("GetEmployeeMaster", new { id = employeeMaster.Employee_Id }, employeeMaster);
        }

        // DELETE: api/Employee/5
        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public async Task<IActionResult> DeleteEmployeeMaster([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeMaster = await _context.EmployeeMaster.SingleOrDefaultAsync(m => m.Employee_Id == id);
            if (employeeMaster == null)
            {
                return NotFound();
            }
            employeeMaster.IsDelete = 1;
            _context.Entry(employeeMaster).State = EntityState.Modified;
            // _context.EmployeeMaster.Remove(employeeMaster);
            await _context.SaveChangesAsync();

            return Ok(employeeMaster);
        }


        [HttpGet]
        [Route("api/Employee/GetDepartment")]
        public IEnumerable<DepartmentMaster1> Details()
        {
            DepartmentDataAccessLayer objdep = new DepartmentDataAccessLayer();
            return objdep.GetAllDepartment();
        }

        private bool EmployeeMasterExists(int id)
        {
            return _context.EmployeeMaster.Any(e => e.Employee_Id == id);
        }


    }
}