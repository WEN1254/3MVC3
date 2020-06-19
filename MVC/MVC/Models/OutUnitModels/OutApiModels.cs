using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace textapi.Models.OutUnitModels
{
    public class OutApiModels
    {
        public OutApiModels(string statuscode,object result,string errormsg)
        {
            StatusCode = statuscode;
            Result = result;
            ErrorMsg = errormsg;
        }
        public string StatusCode { get; set; }
        public object Result { get; set; }
        public string ErrorMsg { get; set; }
    }
    public static class APIStatuCode
    {
        public static string OK = "1";
        public static string Fail = "2";
        public static string Error = "3";
    }
}