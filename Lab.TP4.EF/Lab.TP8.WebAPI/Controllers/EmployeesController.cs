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
using Lab.TP8.EF.Logic;
using Lab.TP8.WebAPI.Models;

namespace Lab.TP8.WebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly EmployeesLogic employeesLogic = new EmployeesLogic();
        

        //GET: api/Employees
        [HttpGet]

        public IHttpActionResult GetEmployees()
        {
            try
            {
                if (employeesLogic.GetAll() == null)
                {
                    return NotFound();
                }
                else
                {
                    List<EmployeesView> employeesView = employeesLogic.GetAll().Select(e => new EmployeesView
                    {
                        Id = e.EmployeeID,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Title = e.Title
                    }).ToList();

                    return Ok(employeesView);
                }
            }catch(Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }

        //GET: api/Employees/5
        [ResponseType(typeof(Employees))]
        public IHttpActionResult GetByID(int id)
        {
            try
            {
                var employee = employeesLogic.Find(id);
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
            }catch(Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployees(int id, Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (!EmployeesExists(id))
            {
                return NotFound();
            }
            employees.EmployeeID = id;
            try
            {
                employeesLogic.Update(employees);
            }        
            catch(Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(Employees))]
        public IHttpActionResult PostEmployees(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                employeesLogic.Add(employees);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = employees.EmployeeID }, employees);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employees))]
        public IHttpActionResult DeleteEmployees(int id)
        {
            Employees employees = employeesLogic.Find(id);
            if (employees == null)
            {
                return NotFound();
            }

            try
            {
                employeesLogic.Delete(id);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

            return Ok(employees);
        }

       

        private bool EmployeesExists(int id)
        {
            return employeesLogic.GetAll().Count(e => e.EmployeeID == id) > 0;
        }
    }
}