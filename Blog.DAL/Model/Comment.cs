using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.DAL.Model
{
    public class Comment
    {
        [Key]
        public long Id { get; set; }

        public long Id2 { get; set; }

        public string Content{ get; set; }

        public string Author { get; set; }

    }
}
