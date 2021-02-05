using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Data
{
    public class Reply
    {
        [Key]
        [Required]
        public int ReplyId { get; set; }

        [Required]
        public string ReplyText { get; set; }

        public DateTimeOffset ReplyCreatedUtc { get; set; }

        [Required]
        public Guid Author { get; set; }


    }
}
