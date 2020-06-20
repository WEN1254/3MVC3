using Dapper;
using MVC.Models.Database;
using MVC.ViewModels.Customer;
using MVC.ViewModels.Customer.Input;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC.Models.Repository.DatabaseLogicLayer
{
    public class CustomerDAO
    {
        private string SQLConnectionStr = ConfigurationManager.ConnectionStrings["MVCContext"].ConnectionString;
        
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
            string Sqlcommand = @" SELECT Password from Customers where Email=@L1";

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
        public IEnumerable<Customer> CheckEmail(string Email)
        {


            string Sqlcommand = @" SELECT * from Customers Where Email=@CustomerEmail";



            IEnumerable<Customer> result;
            using (SqlConnection conn = new SqlConnection(SQLConnectionStr))
            {
                result = conn.Query<Customer>(Sqlcommand, new { CustomerEmail = Email });
            }
            return result;
        }
        public IEnumerable<Customer> Replace(CustomerReplaceInputModel Input)
        {
            string Sqlcommand = @" Update Customers SET Birthday=@c2,CustomerName=@c3,Phone=@c4,Password=@c5
                                    from Customers                                    
                                    where Email=@c1";

            IEnumerable<Customer> result;

            using (SqlConnection conn = new SqlConnection(SQLConnectionStr))
            {
                result = conn.Query<Customer>(Sqlcommand, new { c1 = Input.ReplaceEmail, c2 = Input.ReplaceBirthDay, c3 = Input.ReplaceCustomerName, c4 = Input.ReplacePhone,c5=Input.ReplacePassword });
            }
            return result;
        }

    }
}