using MessageBoard.Models.ViewModel;
using System.Linq;
namespace MessageBoard.Models.ArticleDataModel
{
    internal class LocalArticleEditor : IArticleEditor
    {
        bool IArticleEditor.EditArticle(int articleId, string message)
        {
            MessageDbEntities db = new MessageDbEntities();
            ArticleData article = db.ArticleData.FirstOrDefault(data => data.ArticleId == articleId);

            try
            {
                if (article != null)
                {
                    article.Title = message;
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
