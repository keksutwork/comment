﻿namespace MessageBoard.Models.ArticleDataModel
{
    public interface IArticleEditor
    {
        bool EditArticle(int articleId, string articleTitle);
    }
}