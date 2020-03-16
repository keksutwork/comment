using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MessageBoard.Models.Interfaces;
using MessageBoard.Models.ViewModel;
using MessageBoard.Models;
namespace MessageBoard.Models.CRUDlib
{
    public class LocalArticleDataProvider : IArticleDataProvider
    {
        MessageDbEntities db = new MessageDbEntities();

        IEnumerable<ArticlesViewModel> IArticleDataProvider.GetArticles(int ArticlePerPage)
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

            return query.Take(ArticlePerPage).ToList();
        }

        IEnumerable<ArticlesViewModel> IArticleDataProvider.GetArticlesByAuthor(Guid authorId)
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