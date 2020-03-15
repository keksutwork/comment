using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
namespace MessageBoard.Filters
{
    public class UserAuthFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        void IAuthenticationFilter.OnAuthentication(AuthenticationContext filterContext)
        {
            //由Session進行判斷
            if (string.IsNullOrEmpty( Convert.ToString(filterContext.HttpContext.Session["UserId"]) ) )
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        void IAuthenticationFilter.OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                var tgt = new RouteValueDictionary(new { action="Login" , controller="Login"});
                filterContext.Result = new RedirectToRouteResult(tgt);
            }
        }
    }

}