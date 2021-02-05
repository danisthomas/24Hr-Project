using _24Hr.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Models
{
    public class PostListItem
    {
        public int PostId { get; set; }

        public string PostTitle { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }



    }
}
