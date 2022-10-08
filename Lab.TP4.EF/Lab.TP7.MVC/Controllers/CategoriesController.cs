using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab.TP4.EF.Entities;
using Lab.TP4.EF.Logic;
using Lab.TP7.MVC.Models;

namespace Lab.TP7.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        readonly CategoriesLogic categoriesLogic = new CategoriesLogic();
        // GET: Categories
        public ActionResult Index()
        {
            List<Categories> categories = categoriesLogic.GetAll();

            List<CategoriesView> categoriesView = categories.Select(c => new CategoriesView
            {
                Id = c.CategoryID,
                Name = c.CategoryName,
                Description = c.Description
            }).ToList();

            return View(categoriesView);
        }

        public ActionResult Insert()
        {
            return View("InsertUpdate", new CategoriesView());
        }

        public ActionResult Update(int id)
        {
            
            CategoriesView categoriesView = new CategoriesView
            {
                Id = id
            };
            return View("InsertUpdate", categoriesView);
        }
        [HttpPost]
        public ActionResult InsertUpdate(CategoriesView categoriesView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (categoriesView.Id <= 0)
                    {
                        Categories categories = new Categories
                        {
                            CategoryName = categoriesView.Name,
                            Description = categoriesView.Description
                        };
                        categoriesLogic.Add(categories);
                    }
                    else
                    {
                        Categories categories = new Categories
                        {
                            CategoryID = categoriesView.Id,
                            CategoryName = categoriesView.Name,
                            Description = categoriesView.Description
                        };
                        categoriesLogic.Update(categories);
                    }
                    return RedirectToAction("Index");
                }
                return View(categoriesView);
            }
            catch (Exception)
            {
                return RedirectToAction("InsertUpdateError", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                categoriesLogic.Delete(id);
                var chequeoBorrado = categoriesLogic.Find(id);
                if (chequeoBorrado != null)
                {
                    return RedirectToAction("DeleteError", "Error");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("DeleteError", "Error");
            }
        }      
    }
}