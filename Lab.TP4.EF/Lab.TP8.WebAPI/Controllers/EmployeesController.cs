using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Lab.TP8.EF.Datos;
using Lab.TP8.EF.Entities;
using Lab.TP8.WebAPI.Models;

namespace Lab.TP8.WebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        private NorthwindContext db = new NorthwindContext();

        //GET: api/Employees
        [HttpGet]

        public IHttpActionResult GetEmployees()
        {
            List<Employees> employees = db.Employees.ToList();

            if (employees == null)
            {
                return NotFound();
            }
            else
            {
                List<EmployeesView> employeesView = employees.Select(e => new EmployeesView
                {
                    Id = e.EmployeeID,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Title = e.Title
                }).ToList();

                return Ok(employeesView);
            }
        }

        //GET: api/Employees/5
        [ResponseType(typeof(Employees))]
        public IHttpActionResult GetByID(int id)
        {
            Employees employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                var employeeOk = new EmployeesView
                {
                    Id = employee.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Title = employee.Title
                };
                return Ok(employeeOk);
            }

        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployees(int id, Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employees.EmployeeID)
            {
                return BadRequest();
            }

            db.Entry(employees).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(Employees))]
        public async Task<IHttpActionResult> PostEmployees(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employees);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employees.EmployeeID }, employees);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employees))]
        public async Task<IHttpActionResult> DeleteEmployees(int id)
        {
            Employees employees = await db.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employees);
            await db.SaveChangesAsync();

            return Ok(employees);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeesExists(int id)
        {
            return db.Employees.Count(e => e.EmployeeID == id) > 0;
        }
    }
}