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
    [UserAuthenFilter]
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
            //如果加入成功，導向回後台首頁
            //失敗回CREATE
            bool result;
            if (ModelState.IsValid)
            {
                IArticleCreater creater = ArticleDataControl.CreateArticleCreater();
                result = creater.CreateArticle(article.Title);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "不明錯誤");
            return View();
        }

        public ActionResult Edit(int articleId)
        {
            IArticleReader reader = ArticleDataControl.CreateArticleReader();
            ArticlesViewModel result = reader.GetArticlesById(articleId);
            if(result != null && result.PostBy == Session["UserId"].ToString())
            {
                Session["ArticleId"] = articleId;
                return View(result);
            }
            else
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string Title)
        {
            IArticleEditor editor = ArticleDataControl.CreateArticleEditor();
            try
            {
               var result = editor.EditArticle(int.Parse(Session["ArticleId"].ToString()), Title);
               if(result == true)
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "修改錯誤");
                return View();
            }
            finally
            {
                Session["ArticleId"] = null;
            }
            ModelState.AddModelError("", "修改錯誤");
            return View();
        }

        public ActionResult Delete(int articleId)
        {
            IArticleReader reader = ArticleDataControl.CreateArticleReader();
            ArticlesViewModel result = reader.GetArticlesById(articleId);
            if (result != null && result.PostBy == Session["UserId"].ToString())
            {
                Session["ArticleId"] = articleId;
                return View(result);
            }
            else
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete()
        {
            try
            {
                int articleId = int.Parse(Session["ArticleId"].ToString());
                IArticleDeleter deleter = ArticleDataControl.CreateArticleDeleter();
                var result = deleter.DeleteArticle(articleId);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "刪除錯誤");
                return View();
            }
            finally
            {
                Session["ArticleId"] = null;
            }
            ModelState.AddModelError("", "刪除錯誤");
            return View();
        }

    }
}