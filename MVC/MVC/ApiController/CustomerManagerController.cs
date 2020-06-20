using MVC.Models.Repository.BussinessLogicLayer;
using MVC.ViewModels.Customer;
using MVC.ViewModels.Customer.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using textapi.Models.OutUnitModels;

namespace MVC.ApiControllers
{
    public class CustomerManagerController : ApiController
    {
        private CustomerBLO _CustomerBLO;
        private LoginBLO _LoginBLO;

        public CustomerManagerController()
        {
            _CustomerBLO = new CustomerBLO();
            _LoginBLO = new LoginBLO();
        }

        //商業邏輯層
        [HttpPost]
        public OutApiModels Login([FromBody] CustomerLogin_Inputmodel input)
        {
            //[FromBody] string acc, string pwd

            OutApiModels result;


            var CheckAccount = _LoginBLO.Login_CheckAccount(input);

            OutApiModels error = new OutApiModels(APIStatuCode.Fail, CheckAccount, string.Empty);
            OutApiModels errorPassword = new OutApiModels(APIStatuCode.Error, CheckAccount, string.Empty);
            if (CheckAccount == null)
            {
                return error;
            }
            else
            {
                var CheckPassword = _LoginBLO.Login_CheckPassword(input);
                if (CheckPassword == null)
                {
                    return errorPassword;
                }
                else
                {
                    if (HttpContext.Current.Session != null)
                    {
                        HttpContext.Current.Session.RemoveAll();
                    }

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                      "user",//你想要存放在 User.Identy.Name 的值，通常是使用者帳號
                      DateTime.Now,
                      DateTime.Now.AddMinutes(30),
                      false,//將管理者登入的 Cookie 設定成 Session Cookie
                      "user",//userdata看你想存放啥
                      FormsAuthentication.FormsCookiePath);

                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                    //FormsAuthentication.RedirectFromLoginPage("Admin", false);
                    //var a = HttpContext.Current.User.Identity.IsAuthenticated;

                    result = new OutApiModels(APIStatuCode.OK, "Success", string.Empty);

                    return result;
                }
            }
        }

        [HttpPost]
        public OutApiModels Register([FromBody] CustomerRegister_Inputmodel input)
        {
            var queryresult = _CustomerBLO.Register(input);
            OutApiModels error = new OutApiModels(APIStatuCode.Fail, queryresult, "FAILS");
            OutApiModels success = new OutApiModels(APIStatuCode.OK, queryresult, string.Empty);



            if (queryresult == null)
            {
                return error;
            }
            else
            {
                return success;
            }

        }
        [HttpPost]
        public OutApiModels GetCustomer([FromBody] GetCustomerInput input)
        {
            var queryresult = _LoginBLO.Login_GetCustomer(input);
            OutApiModels error = new OutApiModels(APIStatuCode.Fail, queryresult, "FAILS");
            OutApiModels success = new OutApiModels(APIStatuCode.OK, queryresult, string.Empty);



            if (queryresult == null)
            {
                return error;
            }
            else
            {
                return success;
            }

        }
        public OutApiModels Replace([FromBody] CustomerReplaceInputModel input)
        {
            var queryresult = _CustomerBLO.Replace(input);
            OutApiModels error = new OutApiModels(APIStatuCode.Fail, queryresult, "FAILS");
            OutApiModels success = new OutApiModels(APIStatuCode.OK, queryresult, string.Empty);



            if (queryresult == null)
            {
                return error;
            }
            else
            {
                return success;
            }

        }
        public OutApiModels GetOrder([FromBody] GetCustomerInput input)
        {
            var queryresult = _LoginBLO.Login_GetOrder(input);
            OutApiModels error = new OutApiModels(APIStatuCode.Fail, queryresult, "FAILS");
            OutApiModels success = new OutApiModels(APIStatuCode.OK, queryresult, string.Empty);



            if (queryresult == null)
            {
                return error;
            }
            else
            {
                return success;
            }

        }
    }
}
