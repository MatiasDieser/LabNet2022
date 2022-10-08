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
    public class ShippersController : Controller
    {
        readonly ShippersLogic shippersLogic = new ShippersLogic();
        // GET: Shippers
        public ActionResult Index()
        {
            List<Shippers> shippers = shippersLogic.GetAll();

            List<ShippersView> shippersView = shippers.Select(s => new ShippersView
            {
                Id = s.ShipperID,
                Name = s.CompanyName,
                Phone = s.Phone
            }).ToList();

            return View(shippersView);
        }

        public ActionResult Insert()
        {
            return View("InsertUpdate", new ShippersView());
        }

        public ActionResult Update(int id)
        {
            ShippersView shippersView = new ShippersView
            {
                Id = id
            };
            return View("InsertUpdate", shippersView);
        }

        [HttpPost]
        public ActionResult InsertUpdate(ShippersView shippersView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (shippersView.Id <= 0)
                    {
                        Shippers shippers = new Shippers
                        {
                            CompanyName = shippersView.Name,
                            Phone = shippersView.Phone
                        };
                        shippersLogic.Add(shippers);
                    }
                    else
                    {
                        Shippers shippers = new Shippers
                        {
                            ShipperID = shippersView.Id,
                            CompanyName = shippersView.Name,
                            Phone = shippersView.Phone
                        };
                        shippersLogic.Update(shippers);
                    }
                    return RedirectToAction("Index");
                }
                return View(shippersView);
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
                shippersLogic.Delete(id);
                var chequeoBorrado = shippersLogic.Find(id);
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