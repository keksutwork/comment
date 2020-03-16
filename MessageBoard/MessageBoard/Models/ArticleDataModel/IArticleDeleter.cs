using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard.Models.ArticleDataModel
{
    public interface IArticleDeleter
    {
        bool DeleteArticle(int articleId);
    }
}
