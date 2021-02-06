using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Models
{
    public class ReplyListItem
    {
        public Guid OwnerId { get; set; }

        public int ReplyId { get; set; }
        public string CommentText { get; set; }
        public string ReplyText { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset ReplyCreatedUtc { get; set; }
    }
}
