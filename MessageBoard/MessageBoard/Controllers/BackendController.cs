using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Filters;
using MessageBoard.Models.ViewModel;
using MessageBoard.Models.ArticleDataModel;
namespace MessageBoard.Controllers
{
    [UserAuthFilter]
    public class BackendController : Controller
    {
        
        // GET: Backend/Index
        public ActionResult Index()
        {
            IArticleReader reader = ArticleDataControl.CreateArticleReader();
            var model = reader.GetArticlesByAuthor(Guid.Parse(Session["UserId"].ToString()));
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

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticlesViewModel article)
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ArticlesViewModel article)
        {
            return View();
        }

    }
}