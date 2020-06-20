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
        public List<CustomerReplace_OuputModel> Replace(CustomerReplaceInputModel input)
        {

            List<CustomerReplace_OuputModel> model;

            var CheckAccount = _CustomerDAO.CheckEmail(input.ReplaceEmail);

            var queryresult = _CustomerDAO.Replace(input);

           
                model = queryresult.Select(x => new CustomerReplace_OuputModel
                {
                    ReplaceCustomerName = x.CustomerName,
                    ReplaceEmail = x.Email,
                    ReplacePassword=x.Password,
                    ReplaceBirthday = x.Birthday,
                    ReplacePhone = x.Phone,

                }).ToList();
                return model;
        }
    }
}