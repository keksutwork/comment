using System.Web;
using System.Linq;
using System;

namespace MessageBoard.Models.ArticleDataModel
{
    internal class LocalArticleDeleter : IArticleDeleter
    {
        bool IArticleDeleter.DeleteArticle(int articleId)
        {
            var currentUserId = Guid.Parse(HttpContext.Current.Session["UserId"].ToString());
            MessageDbEntities db = new MessageDbEntities();
            ArticleData deleteTarget = db.ArticleData.FirstOrDefault(data => data.ArticleId == articleId);
            try
            {
                if (deleteTarget.PostBy == currentUserId)
                {
                    db.ArticleData.Remove(deleteTarget);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
