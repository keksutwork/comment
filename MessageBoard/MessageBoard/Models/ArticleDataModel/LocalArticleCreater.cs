using MessageBoard.Models.ViewModel;
using System;
using System.Web;
namespace MessageBoard.Models.ArticleDataModel
{
    public class LocalArticleCreater : IArticleCreater
    {
        bool IArticleCreater.CreateArticle(string message)
        {
            //如果沒捕捉到錯誤，推定為成功加入
            try
            {
                MessageDbEntities db = new MessageDbEntities();
                ArticleData article = new ArticleData()
                {
                    PostBy = Guid.Parse(HttpContext.Current.Session["UserId"].ToString()),
                    PostDate = DateTime.Now,
                    Title = message
                };
                db.ArticleData.Add(article);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}