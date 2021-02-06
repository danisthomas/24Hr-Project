using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _24Hr.Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CommentCreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? CommentModifiedUTC { get; set; }
    }
}
