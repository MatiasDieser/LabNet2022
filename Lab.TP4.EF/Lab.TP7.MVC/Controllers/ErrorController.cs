using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.TP7.MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult InsertUpdateError()
        {
            return View();
        }
        public ActionResult DeleteError()
        {
            return View();
        }
        
        public ActionResult Error404()
        {
            return View();
        }
        
    }
}