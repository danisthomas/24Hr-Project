using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Data
{
    public class Post
    {
        [Key]
        [Required]
        public int PostId { get; set; }

        //[ForeignKey(nameof(Comments))]
        //public int CommentId { get; set; }

        //public virtual Comment Comments { get; set; }

        [Required]
        public string PostTitle { get; set; }
        [Required]
        public string PostText { get; set; }

        public DateTimeOffset PostCreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        [Required]
        public Guid Author { get; set; }

       

    }
}
