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

namespace Lab.TP8.WebAPI.Controllers
{
    public class ShippersController : ApiController
    {
        private NorthwindContext db = new NorthwindContext();

        // GET: api/Shippers
        public IQueryable<Shippers> GetShippers()
        {
            return db.Shippers;
        }

        // GET: api/Shippers/5
        [ResponseType(typeof(Shippers))]
        public async Task<IHttpActionResult> GetShippers(int id)
        {
            Shippers shippers = await db.Shippers.FindAsync(id);
            if (shippers == null)
            {
                return NotFound();
            }

            return Ok(shippers);
        }

        // PUT: api/Shippers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShippers(int id, Shippers shippers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shippers.ShipperID)
            {
                return BadRequest();
            }

            db.Entry(shippers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippersExists(id))
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

        // POST: api/Shippers
        [ResponseType(typeof(Shippers))]
        public async Task<IHttpActionResult> PostShippers(Shippers shippers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shippers.Add(shippers);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = shippers.ShipperID }, shippers);
        }

        // DELETE: api/Shippers/5
        [ResponseType(typeof(Shippers))]
        public async Task<IHttpActionResult> DeleteShippers(int id)
        {
            Shippers shippers = await db.Shippers.FindAsync(id);
            if (shippers == null)
            {
                return NotFound();
            }

            db.Shippers.Remove(shippers);
            await db.SaveChangesAsync();

            return Ok(shippers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShippersExists(int id)
        {
            return db.Shippers.Count(e => e.ShipperID == id) > 0;
        }
    }
}