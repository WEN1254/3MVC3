using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVC.Models.Database;
using Dapper;
using textapi.Models.Database;

namespace MVC.Models.Repository.DatabaseLogicLayer
{
    public class ProductDLO
    {
        private string SQLStr = ConfigurationManager.ConnectionStrings["MVCContext"].ConnectionString;
        public IEnumerable<ProductList> GetAll()
        {
            string SQLcommand= @"select p.ProductID ,p.ProductName,p.SmallClassificationID,ps.Price,ps.Image,p.Quantity,ps.ProductSpecificationID
                                    from Products p
                                    join  (select *
                                    from(
	                                    select ROW_NUMBER()OVER(PARTITION BY [ProductID],[Price] ORDER by [ProductID])as rown,*
	                                    FROM [ProductSpecifications])AS T1
	                                    WHERE rown = 1) ps 
                                    on ps.ProductID=p.ProductID";
            IEnumerable<ProductList> result;
            using(SqlConnection conn=new SqlConnection(SQLStr))
            {
                result = conn.Query<ProductList>(SQLcommand);
            }
            return result;
        }
    }
}