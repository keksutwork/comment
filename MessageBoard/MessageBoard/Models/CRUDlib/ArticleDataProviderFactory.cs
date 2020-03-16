using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MessageBoard.Models.Interfaces;
using MessageBoard.Models;
namespace MessageBoard.Models.CRUDlib
{
    public static class ArticleDataProviderFactory
    {
        public static IArticleDataProvider CreateArticleDataProvider(string type)
        {
            IArticleDataProvider result = null;
            switch (type)
            {
                case "LocalTest":
                    result = new LocalArticleDataProvider();
                    break;
            }
            return result;
        }
    }
}