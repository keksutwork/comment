using MessageBoard.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MessageBoard.Models.ArticleDataModel
{
    public class LocalArticleReader : IArticleReader
    {
        MessageDbEntities db = new MessageDbEntities();

        IEnumerable<ArticlesViewModel> IArticleReader.GetArticles(int ArticleNumber)
        {


            //取得資料
            var query = from article in db.ArticleData
                        join user in db.UserAccount on article.PostBy equals user.UserId
                        orderby article.PostDate descending
                        select new ArticlesViewModel()
                        {
                            ArticleId = article.ArticleId,
                            PostBy = user.AccountName,
                            Title = article.Title,
                            PostDate = article.PostDate,
                        };

            return query.Take(ArticleNumber).ToList();
        }

        IEnumerable<ArticlesViewModel> IArticleReader.GetArticlesByAuthor(Guid authorId)
        {
            var query = from article in db.ArticleData
                        join user in db.UserAccount on article.PostBy equals user.UserId
                        where user.UserId == authorId
                        orderby article.PostDate descending
                        select new ArticlesViewModel()
                        {
                            ArticleId = article.ArticleId,
                            PostBy = user.AccountName,
                            Title = article.Title,
                            PostDate = article.PostDate,
                        };

            return query.ToList();
        }
    }
}