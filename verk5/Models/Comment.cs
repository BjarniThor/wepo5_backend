using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using verk5.Models;

namespace verk5.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int LectureId { get; set; }
        public String CommentText { get; set; }
        public String Commenter { get; set; }

        public Lecture Lecture { get; set; }
    }
}