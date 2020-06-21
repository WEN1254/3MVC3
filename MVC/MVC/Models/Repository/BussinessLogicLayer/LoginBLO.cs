using MVC.Models.Database;
using MVC.Models.Repository.DatabaseLogicLayer;
using MVC.ViewModels.Customer;
using MVC.ViewModels.Customer.Input;
using MVC.ViewModels.Customer.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.Repository.BussinessLogicLayer
{
    public class LoginBLO
    {
        private LoginDAO _LoginDAO;

        public LoginBLO()
        {
            _LoginDAO = new LoginDAO();
        }

        public List<CustomerLogin_Outputmodel> Login_CheckAccount(CustomerLogin_Inputmodel Input)
        {
            List<CustomerLogin_Outputmodel> result;


            var queryresult = _LoginDAO.Login_CheckAccount(Input);

            result = queryresult.Select(x => new CustomerLogin_Outputmodel
            {
                Email = x.Email,

            }).ToList();


            if (result.Count() == 0)
            {

                return null;
            }
            else
            {
                return result;
            }



        }
        public List<CustomerLogin_Outputmodel> Login_CheckPassword(CustomerLogin_Inputmodel Input)
        {
            List<CustomerLogin_Outputmodel> result;

            var queryresult = _LoginDAO.Login_CheckPassword(Input);


            result = queryresult.Select(x => new CustomerLogin_Outputmodel
            {
                CustomerID = x.CustomerID,
                Password = x.Password
            }).ToList();
            if (result.Count!=0)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        public List<GetCustomerOutput> Login_GetCustomer(GetCustomerInput Input)
        {
            List<GetCustomerOutput> result;

            var queryresult = _LoginDAO.Login_GetCustomer(Input.LoginUser);


            result = queryresult.Select(x => new GetCustomerOutput
            {
                CustomerName = x.CustomerName,
                Password=x.Password,
                Email = x.Email,
                Phone=x.Phone,
                BirthDay=x.Birthday
            }).ToList();
            return result;
            
            
        }
        public List<CustomerOrder_OutputModel> Login_GetOrder(GetCustomerInput Input)
        {
            List<CustomerOrder_OutputModel> result;

            var queryresult = _LoginDAO.Login_GetOrder(Input.LoginUser);


            result = queryresult.Select(x => new CustomerOrder_OutputModel
            {
                Email = x.Email,
                OrderID = x.OrderID,
                RecieverName = x.RecieverName,
                ProductName = x.ProductName,
                Colour = x.Colour,
                Image = x.Image,
                BuyQuantity = x.BuyQuantity,
                Price = x.Price,
                ProductTotal = x.ProductTotal

            }).ToList();
            return result;


        }

    }
}