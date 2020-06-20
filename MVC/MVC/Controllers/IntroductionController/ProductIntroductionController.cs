using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers.IntroductionController
{
    public class ProductIntroductionController : Controller
    {

        //Sofas(current)
        //Chairs(current)
        //Tables(current)
        //Beds(current)
        //Cabinet And Dressingtable(current)
        //Accessories
        // GET: ProductIntroduction
        public ActionResult Sofas()
        {
            return View();
        }
        public ActionResult Chairs()
        {
            return View();
        }
        public ActionResult Tables()
        {
            return View();
        }
        public ActionResult Beds()
        {
            return View();
        }
        public ActionResult CabinetAndDressingtable()
        {
            return View();
        }
        public ActionResult Accessories()
        {
            return View();
        }
    }
}