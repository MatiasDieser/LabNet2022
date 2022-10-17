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
using Lab.TP7.MVC.Models;
using Lab.TP8.EF.Datos;
using Lab.TP8.EF.Entities;
using Lab.TP8.EF.Logic;

namespace Lab.TP8.WebAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly CustomersLogic customersLogic = new CustomersLogic();

        // GET: api/Customers
        public IHttpActionResult GetCustomers()
        {
            try
            {
                if (customersLogic.GetAll() == null)
                {
                    return NotFound();
                }
                else
                {
                    List<CustomersView> customersView = customersLogic.GetAll().Select(c => new CustomersView
                    {
                        Id = c.CustomerID,
                        Company = c.CompanyName,
                        ContactName = c.ContactName
                    }).ToList();

                    return Ok(customersView);
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customers))]
        public IHttpActionResult GetCustomers(string id)
        {
            try
            {
                var customer = customersLogic.Find(id);
                if (customer == null)
                {
                    return NotFound();
                }
                else
                {
                    var customerOk = new CustomersView
                    {
                        Id = customer.CustomerID,
                        Company = customer.CompanyName,
                        ContactName = customer.ContactName
                    };
                    return Ok(customerOk);
                }
            }catch(Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomers(string id, Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!CustomersExists(id))
            {
                return NotFound();
            }
            customers.CustomerID = id;
            try
            {
                customersLogic.Update(customers);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customers))]
        public async Task<IHttpActionResult> PostCustomers(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                customersLogic.Add(customers);
            }
            catch (DbUpdateException)
            {
                if (CustomersExists(customers.CustomerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }catch(Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = customers.CustomerID }, customers);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customers))]
        public IHttpActionResult DeleteCustomers(string id)
        {
            Customers customers = customersLogic.Find(id);
            
            if (customers == null)
            {
                return NotFound();
            }

            try
            {
                customersLogic.DeleteByString(id);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

            return Ok(customers);
        }


        private bool CustomersExists(string id)
        {
            return customersLogic.GetAll().Count(e => e.CustomerID == id) > 0;
        }
    }
}