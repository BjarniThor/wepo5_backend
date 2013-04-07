using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace verk5.Models
{
    public class LectureDTO
    {
        public class Lecture
        {
            public int LectureId { get; set; }
            public String Lecturename { get; set; }
            public int CourseId { get; set; }
            
        }
        public IEnumerable<Lecture> Lectures { get; set; } 
        public IEnumerable<Video> Videos { get; set; }
        public IEnumerable<Comment> Comments { get; set; } 
    }
}