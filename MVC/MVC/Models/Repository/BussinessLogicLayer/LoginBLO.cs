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
                Email = x.Email,
                CustomerName = x.CustomerName,
                Phone = x.Phone,
                BirthDay = x.Birthday
            }).ToList();
            return result;


        }

    }
}