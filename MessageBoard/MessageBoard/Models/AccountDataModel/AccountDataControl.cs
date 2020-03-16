using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MessageBoard.Models.AccountDataModel
{
    public static class AccountDataControl
    {
        private static readonly string db = ConfigurationManager.AppSettings["environment"];

        public static IAccountLoginService CreateAccountLoginService()
        {
            IAccountLoginService result = null;
            switch (db)
            {
                case "LocalTest":
                    result = new LocalAccountLoginService();
                    break;
            }
            return result;
        }

        public static IAccountRegisterService CreateAccountRegisterService()
        {
            IAccountRegisterService result = null;
            switch (db)
            {
                case "LocalTest":
                    result = new LocalAccountRegisterService();
                    break;
            }
            return result;
        }
    }
}