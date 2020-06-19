using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.Models.Database;

namespace MVC.Controllers
{
    public class MvcHomeController : Controller
    {
        // GET: MvcHome
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(Customer NewUser)
        {

            return View();
        }
    }
}