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

namespace Lab.TP8.WebAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private NorthwindContext db = new NorthwindContext();

        // GET: api/Customers
        public IHttpActionResult GetCustomers()
        {
            List<Customers> customers = db.Customers.ToList();

            if (customers == null)
            {
                return NotFound();
            }
            else
            {
                List<CustomersView> customersView = customers.Select(c => new CustomersView
                {
                    Id = c.CustomerID,
                    Company = c.CompanyName,
                    ContactName = c.ContactName
                }).ToList();

                return Ok(customersView);
            }
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customers))]
        public IHttpActionResult GetCustomers(string id)
        {
            Customers customer = db.Customers.Find(id);
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
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomers(string id, Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customers.CustomerID)
            {
                return BadRequest();
            }

            db.Entry(customers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
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

        // POST: api/Customers
        [ResponseType(typeof(Customers))]
        public async Task<IHttpActionResult> PostCustomers(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customers);

            try
            {
                await db.SaveChangesAsync();
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
            }

            return CreatedAtRoute("DefaultApi", new { id = customers.CustomerID }, customers);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customers))]
        public async Task<IHttpActionResult> DeleteCustomers(string id)
        {
            Customers customers = await db.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customers);
            await db.SaveChangesAsync();

            return Ok(customers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomersExists(string id)
        {
            return db.Customers.Count(e => e.CustomerID == id) > 0;
        }
    }
}