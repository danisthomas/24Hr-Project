using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _24Hr.Models
{
    public class CommentCreate
    {
        public int? CommentId { get; set; }
        [Required, MaxLength(120, ErrorMessage = "You have exceeded the maximum character limit."),
            MinLength(2, ErrorMessage = "You must input more then two characters.")]
        public string CommentText { get; set; }

        public DateTimeOffset CommentCreatedUtc { get; set; }
        public int? ReplyId { get; set; }
    }
}
