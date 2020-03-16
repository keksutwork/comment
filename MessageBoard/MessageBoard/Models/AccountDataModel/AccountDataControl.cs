using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Reflection;

namespace MessageBoard.Models.AccountDataModel
{
    public static class AccountDataControl
    {
        //反射用資料
        private static readonly string db = ConfigurationManager.AppSettings["environment"];
        private static readonly string assemblyName = ConfigurationManager.AppSettings["DataControlAssemblyName"];
        private static readonly string comNamesapce = "MessageBoard.Models.AccountDataModel";

        public static IAccountLoginService CreateAccountLoginService()
        {
            string className = $"{comNamesapce}.{db}AccountLoginService";
            return (IAccountLoginService)Assembly.Load(assemblyName).CreateInstance(className);
        }

        public static IAccountRegisterService CreateAccountRegisterService()
        {

            string className = $"{comNamesapce}.{db}AccountRegisterService";
            return (IAccountRegisterService)Assembly.Load(assemblyName).CreateInstance(className);
        }
    }
}