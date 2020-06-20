using Dapper;
using MVC.Models.Database;
using MVC.ViewModels.Customer;
using MVC.ViewModels.Customer.Input;
using MVC.ViewModels.Customer.Output;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC.Models.Repository.DatabaseLogicLayer
{
    public class LoginDAO
    {
        private string SQLConnectionStr = ConfigurationManager.ConnectionStrings["MVCContext"].ConnectionString;
        public IEnumerable<Customer> GetAllMember()
        {
            string SQLcommand = @"SELECT * FROM Customers";

            IEnumerable<Customer> result;

            using (SqlConnection conn = new SqlConnection(SQLConnectionStr))
            {
                result = conn.Query<Customer>(SQLcommand);
            }

            return result;
        }
        public IEnumerable<Customer> Login_CheckAccount(CustomerLogin_Inputmodel Input)
        {
            string Sqlcommand = @" SELECT Email from Customers where Email=@L1";

            IEnumerable<Customer> result;
            using (SqlConnection conn = new SqlConnection(SQLConnectionStr))
            {
                result = conn.Query<Customer>(Sqlcommand, new { L1 = Input.LoginEmail });
            }
            return result;
        }
        public IEnumerable<Customer> Login_CheckPassword(CustomerLogin_Inputmodel Input)
        {
            string Sqlcommand = @" SELECT CustomerID,Password from Customers where Password=@L1";

            IEnumerable<Customer> result;
            using (SqlConnection conn = new SqlConnection(SQLConnectionStr))
            {
                result = conn.Query<Customer>(Sqlcommand, new { L1 = Input.LoginPassword });
            }
            return result;
        }
        
        public IEnumerable<Customer> Register(CustomerRegister_Inputmodel Input)
        {
            string Sqlcommand = @" INSERT INTO Customers(Email,Password,Birthday,CustomerName,Phone)
                                   VALUES (@c1,@c2,@c3,@c4,@c5)";

            IEnumerable<Customer> result;

            using (SqlConnection conn = new SqlConnection(SQLConnectionStr))
            {
                result = conn.Query<Customer>(Sqlcommand, new { c1 = Input.RegisterEmail, c2 = Input.RegisterPassword, c3 = Input.RegisterBirthday, c4 = Input.RegisterCustomerName, c5 = Input.RegisterPhone });
            }
            return result;
        }
        public IEnumerable<Customer> CheckAccount(string Email)
        {


            string Sqlcommand = @" SELECT * from Customers Where Email=@Email";



            IEnumerable<Customer> result;
            using (SqlConnection conn = new SqlConnection(SQLConnectionStr))
            {
                result = conn.Query<Customer>(Sqlcommand, new { CustomerEmail = Email });
            }
            return result;
        }
        public IEnumerable<Customer> Login_GetCustomer(string Email)
        {
            string Sqlcommand = @" SELECT * from Customers Where Email=@CustomerEmail";
            IEnumerable<Customer> result;
            using (SqlConnection conn = new SqlConnection(SQLConnectionStr))
            {
                result = conn.Query<Customer>(Sqlcommand, new { CustomerEmail = Email });
            }
            return result;
        }
        public IEnumerable<CustomerOrder_OutputModel> Login_GetOrder(string Email)
        {
            string Sqlcommand = @"
            select c.Email,od.OrderID,o.RecieverName,p.ProductName,ps.Colour,ps.Image,od.BuyQuantity,od.Price,(od.BuyQuantity*od.Price) as ProductTotal
            from OrderDetail od
            inner join Orders o on o.OrderID=od.OrderID
            inner join ProductSpecifications ps on ps.ProductSpecificationID=od.ProductSpecificationID
            inner join Products p on p.ProductID=ps.ProductID
            inner join Customers c on c.CustomerID=o.CustomerID
            where c.Email=N@Email";

            IEnumerable<CustomerOrder_OutputModel> result;
            using (SqlConnection conn = new SqlConnection(SQLConnectionStr))
            {
                result = conn.Query<CustomerOrder_OutputModel>(Sqlcommand, new { CustomerEmail = Email });
            }
            return result;
        }
    }
}