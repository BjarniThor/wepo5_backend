using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace verk5.Models
{
    public class CourseDTO
    {
        public class Course
        {
            public int CourseId { get; set; }
            public String Coursename { get; set; }
        }
        public IEnumerable<Course> Courses { get; set; } 
    }
}