using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageBoard.Models.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "帳號名稱")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "{0}的字數上限為{1}個字。")]
        public string AccountName { get; set; }

        [Display(Name = "密碼")]
        [StringLength(20, ErrorMessage = "{0}的字數上限為{1}個字。")]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string AccountPassword { get; set; }
    }
}