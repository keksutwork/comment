using MessageBoard.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace MessageBoard.Models.ArticleDataModel
{
    public interface IArticleReader
    {
        IEnumerable<ArticlesViewModel> GetArticles(int ArticleNumber);
        IEnumerable<ArticlesViewModel> GetArticlesByAuthor(Guid authorId);
        ArticlesViewModel GetArticlesById(int articleId);
    }
}