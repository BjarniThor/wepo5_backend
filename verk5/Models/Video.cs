using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace verk5.Models
{
    public class Video
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Url { get; set; }
        public int LectureId { get; set; }

        //Navigational property to get to owner of video
        //i.e. Video -> CourseId -> TeacherId
        public Lecture Lecture { get; set; }
    }
}