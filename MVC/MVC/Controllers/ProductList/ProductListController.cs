using Microsoft.Ajax.Utilities;
using MVC.Models;
using MVC.Models.Database;
using MVC.Models.Repository.BussinessLogicLayer;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ProductListController : Controller
    {
        private ProductBLO _ProductBLO = new ProductBLO();
        private _1MVC1Model db = new _1MVC1Model();
        public ProductListController()
        {
            _ProductBLO = new ProductBLO();
        }
        // GET: ProductList
        public ActionResult ProductInformation(int id)
        {
            var productCategory = db.ProductSpecifications.Find(id);
            var data = productCategory.Product.ProductSpecifications.ToList();
            return View(data);
            //var productCategory = db.Products.Find(id);
            //var data = productCategory.ProductSpecifications.ToList();
            //return View(data);
        }
     
        public ActionResult New(string sortOrder)
        {
            var queryresult = _ProductBLO.GetAll();
            ViewBag.QuantityParm = String.IsNullOrEmpty(sortOrder) ? "Quantity" : "Quantity";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name" : "Name";
            ViewBag.NamedescSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "Name_desc";
            ViewBag.PriceSortParm = String.IsNullOrEmpty(sortOrder) ? "Price" : "Price";
            ViewBag.PricedescSortParm = String.IsNullOrEmpty(sortOrder) ? "Price_desc" : "Price_desc";
            ViewBag.ResetParm = String.IsNullOrEmpty(sortOrder) ? "" : "";
            switch (sortOrder)
            {
                case "Quantity":
                    queryresult = queryresult.OrderBy(s => s.Quantity).ToList();
                    break;
                case "Name":
                    queryresult = queryresult.OrderBy(s => s.ProductName).ToList();
                    break;
                case "Name_desc":
                    queryresult = queryresult.OrderByDescending(s => s.ProductName).ToList();
                    break;
                case "Price":
                    queryresult = queryresult.OrderBy(s => s.Price).ToList();
                    break;
                case "Price_desc":
                    queryresult = queryresult.OrderByDescending(s => s.Price).ToList();
                    break;
                default:
                    break;
            }
            return View(queryresult);
        }
        public ActionResult Bestsellers(string sortOrder)
        {
            var queryresult = _ProductBLO.GetAll().OrderBy(s=>s.Quantity).Take(25);
            ViewBag.QuantityParm = String.IsNullOrEmpty(sortOrder) ? "Quantity" : "Quantity";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name" : "Name";
            ViewBag.NamedescSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "Name_desc";
            ViewBag.PriceSortParm = String.IsNullOrEmpty(sortOrder) ? "Price" : "Price";
            ViewBag.PricedescSortParm = String.IsNullOrEmpty(sortOrder) ? "Price_desc" : "Price_desc";
            ViewBag.ResetParm = String.IsNullOrEmpty(sortOrder) ? "" : "";
            switch (sortOrder)
            {
                case "Quantity":
                    queryresult = queryresult.OrderBy(s => s.Quantity).ToList();
                    break;
                case "Name":
                    queryresult = queryresult.OrderBy(s => s.ProductName).ToList();
                    break;
                case "Name_desc":
                    queryresult = queryresult.OrderByDescending(s => s.ProductName).ToList();
                    break;
                case "Price":
                    queryresult = queryresult.OrderBy(s => s.Price).ToList();
                    break;
                case "Price_desc":
                    queryresult = queryresult.OrderByDescending(s => s.Price).ToList();
                    break;
                default:
                    break;
            }
            return View(queryresult);
        }
        public ActionResult Category(int type ,string sortOrder)
        {
            var queryresult = _ProductBLO.GetAll().Where(x => x.SmallClassificationID == type);
            ViewBag.QuantityParm = String.IsNullOrEmpty(sortOrder) ? "Quantity" : "Quantity";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name" : "Name";
            ViewBag.NamedescSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "Name_desc";
            ViewBag.PriceSortParm = String.IsNullOrEmpty(sortOrder) ? "Price" : "Price";
            ViewBag.PricedescSortParm = String.IsNullOrEmpty(sortOrder) ? "Price_desc" : "Price_desc";
            ViewBag.ResetParm = String.IsNullOrEmpty(sortOrder) ? "" : "";
            switch (sortOrder)
            {
                case "Quantity":
                    queryresult = queryresult.OrderBy(s => s.Quantity).ToList();
                    break;
                case "Name":
                    queryresult = queryresult.OrderBy(s => s.ProductName).ToList();
                    break;
                case "Name_desc":
                    queryresult = queryresult.OrderByDescending(s => s.ProductName).ToList();
                    break;
                case "Price":
                    queryresult = queryresult.OrderBy(s => s.Price).ToList();
                    break;
                case "Price_desc":
                    queryresult = queryresult.OrderByDescending(s => s.Price).ToList();
                    break;
                default:
                    break;
            }
             return View(queryresult);          
        }
       
    }
}