using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MessageBoard
{
    [MetadataType(typeof(UserAccountMetaData))]
    public partial class UserAccount
    {
        
        public class UserAccountMetaData
        {
            public System.Guid UserId { get; set; }

            [Required(AllowEmptyStrings = false)]
            [StringLength(20, ErrorMessage = "{0}的字數上限為{1}個字。")]
            public string AccountName { get; set; }

            [StringLength(64, ErrorMessage = "{0}的字數上限為{1}個字。")]
            [Required(AllowEmptyStrings = false)]
            [DataType(DataType.Password)]
            public string AccountPassword { get; set; }
        }
    }
}