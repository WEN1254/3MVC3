using MVC.Models.Repository.DatabaseLogicLayer;
using MVC.ViewModels.Customer.Input;
using MVC.ViewModels.Customer.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.Repository.BussinessLogicLayer
{
    public class CustomerBLO
    {
        private CustomerDAO _CustomerDAO;


        public CustomerBLO()
        {
            _CustomerDAO = new CustomerDAO();
        }
        public List<Customer_GetAll_OutModel> GetAllMember()
        {
            List<Customer_GetAll_OutModel> result;

            var queryresult = _CustomerDAO.GetAllMember();


            result = queryresult.Select(x => new Customer_GetAll_OutModel
            {
                CustomerID = x.CustomerID,
                CustomerName = x.CustomerName,
                Birthday = x.Birthday,
                Email = x.Email,
                Password = x.Password,
                Phone = x.Phone,
            }).ToList();

            return result;
        }
        public List<CustomerRegister_Outputmodel> Register(CustomerRegister_Inputmodel input)
        {

            List<CustomerRegister_Outputmodel> model;

            var CheckAccount = _CustomerDAO.CheckEmail(input.RegisterEmail);

            var queryresult = _CustomerDAO.Register(input);

            if (CheckAccount.Count() == 0)
            {
                model = queryresult.Select(x => new CustomerRegister_Outputmodel
                {
                    RegisterCustomerName = x.CustomerName,
                    RegisterPassword = x.Password,
                    RegisterEmail = x.Email,
                    RegisterBirthday = x.Birthday,
                    RegisterPhone = x.Phone,

                }).ToList();

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}