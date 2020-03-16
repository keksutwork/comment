using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBoard.Models.ViewModel;

namespace MessageBoard.Models.Interfaces
{
    public interface IArticleDataProvider
    {
        IEnumerable<ArticlesViewModel> GetArticles(int ArticlePerPage);
        IEnumerable<ArticlesViewModel> GetArticlesByAuthor(Guid authorId);
    }
}
