using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models.Repository.DatabaseLogicLayer;


namespace MVC.Models.Repository.BussinessLogicLayer
{
    public class ProductBLO
    {
        private ProductDLO _ProductDLO;

        public ProductBLO()
        {
            _ProductDLO = new ProductDLO();
        }
        public List<ProductListViewModel> GetAll()
        {
            List<ProductListViewModel> result;
            var queryresult = _ProductDLO.GetAll();
             result = queryresult.Select(x => new ProductListViewModel
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                Price = x.Price,
                Image = x.Image,
                Quantity = x.Quantity,
                SmallClassificationID=x.SmallClassificationID,
                 ProductSpecificationID=x.ProductSpecificationID
             }).ToList();

            return result;
        }
        //Results = Results.OrderBy(s => s.Quantity).ToList();
        //public List<ProductListViewModel> GetLighting()
        //{
        //    var queryresult = this.GetAll();
        //    List<ProductListViewModel> liststr = new List<ProductListViewModel>();
        //    liststr = queryresult.ToList();
        //    return liststr;
        //}

    }
}