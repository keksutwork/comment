using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MessageBoard.Models.ArticleDataModel
{
    public class ArticleDataControl
    {
        private static readonly string db = ConfigurationManager.AppSettings["environment"];

        public static IArticleReader CreateArticleReader()
        {
            IArticleReader result = null;
            switch (db)
            {
                case "LocalTest":
                    result = new LocalArticleReader();
                    break;
            }
            return result;
        }

        public static IArticleCreater CreateArticleCreater()
        {
            IArticleCreater result = null;
            switch (db)
            {
                case "LocalTest":
                    result = new LocalArticleCreater();
                    break;
            }
            return result;
        }

        public static IArticleEditor CreateArticleEditor()
        {
            IArticleEditor result = null;
            switch (db)
            {
                case "LocalTest":
                    result = new LocalArticleEditor();
                    break;
            }
            return result;
        }

        public static IArticleDeleter CreateArticleDeleter()
        {
            IArticleDeleter result = null;
            switch (db)
            {
                case "LocalTest":
                    result = new LocalArticleDeleter();
                    break;
            }
            return result;
        }
    }
}