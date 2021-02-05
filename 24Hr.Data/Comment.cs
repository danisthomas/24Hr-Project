using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Data
{
   public class Comment
   {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
        public Guid CommentAuthor { get; set; }

        [ForeignKey(nameof(Replies))]
        public int ReplyId { get; set; }

        public virtual Reply Replies { get; set; }

        public DateTimeOffset CommentCreatedUtc { get; set; }
        public DateTimeOffset CommentModifiedUtc { get; set; }

        public Guid Author { get; set; }


    }
}
