using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MessageBoard
{
    [MetadataType(typeof(ArticleDataMetaData))]
    public partial class ArticleData
    {
        public class ArticleDataMetaData
        {

            public int ArticleId { get; set; }

            
            [Required]
            public System.Guid PostBy { get; set; }

            
            [StringLength(20,ErrorMessage = "{0}的字數上限為{1}個字。")]
            public string Title { get; set; }

            [Required]
            public System.DateTime PostDate { get; set; }

            
            public int ClickCount { get; set; }
      }
    }
}