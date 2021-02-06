using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Data
{
    public class Reply
    {
        public Guid OwnerId { get; set; }
        [Key]
        [Required]
        public int ReplyId { get; set; }

        [Required]
        public string ReplyText { get; set; }

        public DateTimeOffset ReplyCreatedUtc { get; set; }

        [Required]
        public Guid Author { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }

        public virtual Comment comment { get; set; }


    }
}
