using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Reflection;

namespace MessageBoard.Models.ArticleDataModel
{
    public class ArticleDataControl
    {
        //反射用資料
        private static readonly string db = ConfigurationManager.AppSettings["environment"];
        private static readonly string assemblyName = ConfigurationManager.AppSettings["DataControlAssemblyName"];
        private static readonly string comNamesapce = "MessageBoard.Models.ArticleDataModel";

        public static IArticleReader CreateArticleReader()
        {
            string className = $"{comNamesapce}.{db}ArticleReader";
            return (IArticleReader)Assembly.Load(assemblyName).CreateInstance(className);
        }

        public static IArticleCreater CreateArticleCreater()
        {
            string className = $"{comNamesapce}.{db}ArticleCreater";
            return (IArticleCreater)Assembly.Load(assemblyName).CreateInstance(className);
        }

        public static IArticleEditor CreateArticleEditor()
        {
            string className = $"{comNamesapce}.{db}ArticleEditor";
            return (IArticleEditor)Assembly.Load(assemblyName).CreateInstance(className);
        }

        public static IArticleDeleter CreateArticleDeleter()
        {
            string className = $"{comNamesapce}.{db}ArticleDeleter";
            return (IArticleDeleter)Assembly.Load(assemblyName).CreateInstance(className);
        }
    }
}