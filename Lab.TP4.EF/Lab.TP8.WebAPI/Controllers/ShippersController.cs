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
    public class ShippersController : ApiController
    {
        private readonly ShippersLogic shippersLogic = new ShippersLogic();

        // GET: api/Shippers
        public IHttpActionResult GetShippers()
        {
            try
            {
                if (shippersLogic.GetAll() == null)
                {
                    return NotFound();
                }
                else
                {
                    List<ShippersView> shippersView = shippersLogic.GetAll().Select(s => new ShippersView
                    {
                        Id = s.ShipperID,
                        Name = s.CompanyName,
                        Phone = s.Phone
                    }).ToList();

                    return Ok(shippersView);
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: api/Shippers/5
        [ResponseType(typeof(Shippers))]
        public IHttpActionResult GetShippers(int id)
        {
            try
            {
                var shipper = shippersLogic.Find(id);
                if (shipper == null)
                {
                    return NotFound();
                }
                else
                {
                    var shipperOk = new ShippersView
                    {
                        Id = shipper.ShipperID,
                        Name = shipper.CompanyName,
                        Phone = shipper.Phone
                    };
                    return Ok(shipperOk);
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Shippers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShippers(int id, Shippers shippers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!ShippersExists(id))
            {
                return NotFound();
            }
            shippers.ShipperID = id;

            try
            {
                shippersLogic.Update(shippers);
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
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Shippers
        [ResponseType(typeof(Shippers))]
        public IHttpActionResult PostShippers(Shippers shippers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try 
            { 
                shippersLogic.Add(shippers); 
            }
            catch(Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = shippers.ShipperID }, shippers);
        }

        // DELETE: api/Shippers/5
        [ResponseType(typeof(Shippers))]
        public IHttpActionResult DeleteShippers(int id)
        {
            Shippers shippers = shippersLogic.Find(id);
            if (shippers == null)
            {
                return NotFound();
            }

            shippersLogic.Delete(id);

            return Ok(shippers);
        }

        private bool ShippersExists(int id)
        {
            return shippersLogic.GetAll().Count(e => e.ShipperID == id) > 0;
        }
    }
}