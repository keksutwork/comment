using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MessageBoard
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務

            // Web API 路由
            config.MapHttpAttributeRoutes();

            //取得文章資料用的路徑
            config.Routes.MapHttpRoute(
                name: "GetArticleApi",
                routeTemplate: "api/{controller}/{AritclePerPage}",
                defaults: new { AritclePerPage = RouteParameter.Optional}
            );

            //新增修改刪除文章用的路徑
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
