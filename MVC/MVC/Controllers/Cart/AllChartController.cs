using MVC.Models;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers.Cart
{
    public class AllChartController : Controller
    {
        // GET: AllChart
        public ActionResult Index()
        {
            using (mvcContext db = new mvcContext())
            {

                string sqlQuery = @"select p.ProductID,p.ProductName,p.Quantity,p.Price,ps.Image
                                    from products p
                                    inner join ProductSpecifications ps on p.ProductID=ps.ProductID";
                var Results = db.Database.SqlQuery<AllChartViewModels>(sqlQuery).ToList();
                return View(Results);
            }
        }

        
    }
}