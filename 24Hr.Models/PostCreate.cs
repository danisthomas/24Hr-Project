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
    public class PostCreate
    {
        [Required]
        [MinLength(2,ErrorMessage ="Please enter at least 2 Characters.")]
        [MaxLength(100,ErrorMessage ="Too Many Characters, Limit 150.")]
        public string PostTitle { get; set; }

        [Required]
        [MaxLength(8000)]
        public string PostText { get; set; }

        
    }
}
