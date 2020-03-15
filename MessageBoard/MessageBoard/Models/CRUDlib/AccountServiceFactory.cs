using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MessageBoard.Models.Interfaces;
using MessageBoard.Models.CRUDlib;
namespace MessageBoard.Models.CRUDlib
{
    public class AccountServiceFactory
    {
        public static IAccountService CreateAccountService(string type)
        {
            IAccountService result = null;
            switch (type)
            {
                case "LocalTest":
                    result = new LocalAccountService();
                    break;
            }
            return result;
        }
    }



}