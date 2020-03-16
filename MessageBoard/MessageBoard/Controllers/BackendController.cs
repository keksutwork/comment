using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Filters;
using MessageBoard.Models.ViewModel;
using MessageBoard.Models.CRUDlib;
using MessageBoard.Models.Interfaces;
using System.Configuration;
namespace MessageBoard.Controllers
{
    [UserAuthFilter]
    public class BackendController : Controller
    {
        
        // GET: Backend/Index
        public ActionResult Index()
        {
            //todo: get articles by author
            IArticleDataProvider provider = ArticleDataProviderFactory.CreateArticleDataProvider(ConfigurationManager.AppSettings["environment"]);
            IEnumerable<ArticlesViewModel> model = provider.GetArticlesByAuthor(Guid.Parse(Session["UserId"].ToString()));
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticlesViewModel article)
        {
            return View();
        }

    }
}