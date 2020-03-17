using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Models.ViewModel;
using MessageBoard.Models.ArticleDataModel;
namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
       public ActionResult Index()
        {
            IArticleReader reader = ArticleDataControl.CreateArticleReader();
            IEnumerable<ArticlesViewModel> model = reader.GetArticles(50);
            return View(model);
        }
    }
}