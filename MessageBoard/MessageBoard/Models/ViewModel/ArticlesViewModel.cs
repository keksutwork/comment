using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageBoard.Models.ViewModel
{
    public class ArticlesViewModel
    {
        [Display(Name = "編號")]
        public int ArticleId { get; set; }

        [Display(Name = "發文者")]
        public string PostBy { get; set; }

        [Display(Name = "留言")]
        [MaxLength(20)]
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Display(Name = "發文日期")]
        public System.DateTime PostDate { get; set; }

    }
}