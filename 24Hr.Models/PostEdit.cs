﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Models
{
    public class PostEdit
    {
        public int PostId { get; set; }

        public string PostTitle { get; set; }
        public string PostText { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }


    }
}
