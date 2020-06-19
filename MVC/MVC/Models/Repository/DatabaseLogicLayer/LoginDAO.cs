﻿using Dapper;
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
            string Sqlcommand = @" SELECT Password from Customers where Password=@L1";

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
    }
}