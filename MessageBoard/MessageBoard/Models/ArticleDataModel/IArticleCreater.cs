namespace MessageBoard.Models.ArticleDataModel
{
    public interface IArticleCreater
    {
        bool CreateArticle(string message);
    }
}