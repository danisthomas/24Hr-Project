using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Models
{
    public class PostDetail
    {
        public int PostId { get; set; }

        public string PostTitle { get; set; }

        public string PostText { get; set; }

        [Display(Name="Post Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public string CommentTitle { get; set; }

        public string CommentText { get; set; }

        [Display(Name ="Comment Created")]
        public DateTimeOffset CommentCreated { get; set; }

        public Guid CommentAuthor { get; set; }


    }
}
