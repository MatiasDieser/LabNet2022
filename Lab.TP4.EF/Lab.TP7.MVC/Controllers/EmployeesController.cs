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
    public class EmployeesController : Controller
    {
        readonly EmployeesLogic employeesLogic = new EmployeesLogic();
        // GET: Employees
        public ActionResult Index()
        {
            List<Employees> employees = employeesLogic.GetAll();

            List<EmployeesView> employeesView = employees.Select(e => new EmployeesView
            {
                Id = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Title = e.Title
            }).ToList();
            
            return View(employeesView);
        }

        public ActionResult Insert()
        {
            return View("InsertUpdate", new EmployeesView());
        }
        public ActionResult Update(int id)
        {
            
            EmployeesView employeesView = new EmployeesView
            {
                Id=id
            };
            return View("InsertUpdate", employeesView);
        }

        [HttpPost]
        public ActionResult InsertUpdate(EmployeesView employeesView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(employeesView.Id <= 0)
                    {
                        Employees employees = new Employees
                        {                           
                            FirstName = employeesView.FirstName,
                            LastName = employeesView.LastName,
                            Title = employeesView.Title
                        };
                        employeesLogic.Add(employees);
                    }
                    else
                    {
                        Employees employees = new Employees
                        {
                            EmployeeID = employeesView.Id,
                            FirstName = employeesView.FirstName,
                            LastName = employeesView.LastName,
                            Title = employeesView.Title
                        };
                        employeesLogic.Update(employees);
                    }
                    return RedirectToAction("Index");
                }
                return View(employeesView);
            }
            catch(Exception)
            {
                return RedirectToAction("InsertUpdateError", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                employeesLogic.Delete(id);
                var chequeoBorrado = employeesLogic.Find(id);
                if(chequeoBorrado != null)
                {
                    return RedirectToAction("DeleteError", "Error");
                }
                else
                {
                    return RedirectToAction("Index");
                }
                
            }
            catch(Exception)
            {
                return RedirectToAction("DeleteError", "Error");
            }
        }       
    }
}