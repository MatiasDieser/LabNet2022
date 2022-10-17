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
    public class CategoriesController : ApiController
    {
        private readonly CategoriesLogic categoriesLogic = new CategoriesLogic();

        // GET: api/Categories
        public IHttpActionResult GetCategories()
        {
            try
            {
                if (categoriesLogic.GetAll() == null)
                {
                    return NotFound();
                }
                else
                {
                    List<CategoriesView> categoriesView = categoriesLogic.GetAll().Select(c => new CategoriesView
                    {
                        Id = c.CategoryID,
                        Name = c.CategoryName,
                        Description = c.Description
                    }).ToList();

                    return Ok(categoriesView);
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Categories))]
        public IHttpActionResult GetCategories(int id)
        {
            try
            {
                var categorie = categoriesLogic.Find(id);
                if (categorie == null)
                {
                    return NotFound();
                }
                else
                {
                    var categorieOk = new CategoriesView
                    {
                        Id = categorie.CategoryID,
                        Name = categorie.CategoryName,
                        Description = categorie.Description
                    };
                    return Ok(categorieOk);
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategories(int id, Categories categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!CategoriesExists(id))
            {
                return NotFound();
            }
            categories.CategoryID = id;
            try
            {
                categoriesLogic.Update(categories);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ResponseType(typeof(Categories))]
        public IHttpActionResult PostCategories(Categories categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                categoriesLogic.Add(categories);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = categories.CategoryID }, categories);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Categories))]
        public IHttpActionResult DeleteCategories(int id)
        {
            Categories categories = categoriesLogic.Find(id);
            if (categories == null)
            {
                return NotFound();
            }

            try
            {
                categoriesLogic.Delete(id);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

            return Ok(categories);
        }


        private bool CategoriesExists(int id)
        {
            return categoriesLogic.GetAll().Count(e => e.CategoryID == id) > 0;
        }
    }
}