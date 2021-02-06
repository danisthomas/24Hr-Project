using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _24Hr.Models
{
    public class CommentNewList
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public string PostTitle { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CommentCreatedUTC { get; set; }
        public int PostId { get; set; }
    }
}
