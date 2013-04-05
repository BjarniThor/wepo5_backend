using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace verk5.Models
{
    public class Lecture
    {
        public int Id { get; set; }
        public String Lecturename { get; set; }
        public int CourseId { get; set; }

        public Course Course { get; set; }
        [JsonIgnore]
        public ICollection<Video> Videos { get; set; } 
    }
}