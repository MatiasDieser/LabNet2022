using Lab.TP4.EF.Entities;
using Lab.TP4.EF.Logic;
using Lab.TP7.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.TP7.MVC.Controllers
{
    public class CustomersController : Controller
    {
        readonly CustomersLogic customersLogic = new CustomersLogic();
        // GET: Customers
        public ActionResult Index()
        {
            List<Customers> customers = customersLogic.GetAll();

            List<CustomersView> customersView = customers.Select(c => new CustomersView
            {
                Id = c.CustomerID,
                Company = c.CompanyName,
                ContactName = c.ContactName
            }).ToList();

            return View(customersView);
        }

        public ActionResult Insert(string id)
        {
            
            return View("InsertUpdate", new CustomersView
            {
                Id = id
            });
        }

        public ActionResult Update(string id)
        {
            CustomersView customersView = new CustomersView
            {
                Id = id
            };
            return View("InsertUpdate", customersView);
        }

        [HttpPost]
        public ActionResult InsertUpdate(CustomersView customersView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var findCustomer = customersLogic.Find(customersView.Id);
                    if (findCustomer == null)
                    {
                        Customers customers = new Customers
                        {
                            CustomerID = customersView.Id,
                            CompanyName = customersView.Company,
                            ContactName = customersView.ContactName
                        };
                        customersLogic.Add(customers);
                    }
                    else
                    {
                        Customers customers = new Customers
                        {
                            CustomerID = customersView.Id,
                            CompanyName = customersView.Company,
                            ContactName = customersView.ContactName
                        };
                        customersLogic.Update(customers);
                    }
                    return RedirectToAction("Index");
                }
                return View(customersView);
            }
            catch (Exception)
            {
                return RedirectToAction("InsertUpdateError", "Error");
            }
        }

        public ActionResult Delete(string id)
        {
            try
            {
                customersLogic.DeleteByString(id);
                var chequeoBorrado = customersLogic.Find(id);
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