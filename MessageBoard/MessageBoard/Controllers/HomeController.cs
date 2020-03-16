using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Models;
using MessageBoard.Models.ViewModel;
using MessageBoard.Models.CRUDlib;
using MessageBoard.Models.Interfaces;
using System.Configuration;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult MessageBoard()
        {
            IArticleDataProvider provider = ArticleDataProviderFactory.CreateArticleDataProvider(ConfigurationManager.AppSettings["environment"]);
            
            return View(provider.GetArticles(50));
        }
    }
}