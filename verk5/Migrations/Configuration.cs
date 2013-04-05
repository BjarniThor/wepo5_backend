using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;
using verk5.Models;

namespace verk5.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<verk5.Models.verk5Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(verk5Context ctx)
        {
            WebSecurity.InitializeDatabaseConnection(
                "DefaultConnection",
                "UserProfile",
                "UserId",
                "UserName", autoCreateTables: true);

            if (!Roles.RoleExists("Teacher"))
                Roles.CreateRole("Teacher");

            if (!Roles.RoleExists("Student"))
                Roles.CreateRole("Student");

            if (!WebSecurity.UserExists("dabs"))
                WebSecurity.CreateUserAndAccount(
                    "dabs",
                    "password");

            if (!WebSecurity.UserExists("bibz"))
                WebSecurity.CreateUserAndAccount(
                    "bibz",
                    "password");

            if (!Roles.GetRolesForUser("dabs").Contains("Teacher"))
                Roles.AddUsersToRoles(new[] { "dabs" }, new[] { "Teacher" });

            if (!Roles.GetRolesForUser("bibz").Contains("Student"))
                Roles.AddUsersToRoles(new[] { "bibz" }, new[] { "Student" });

            var course = new Course
            {
                Coursename = "Vefforritun II"
            };

            ctx.Courses.Add(course);

            var lecture = new List<Lecture>
                {
                    new Lecture
                        {
                            CourseId = course.Id,
                            Course = course,
                            Lecturename = "First lecture"
                        },                
                    new Lecture
                        {
                            CourseId = course.Id,
                            Course = course,
                            Lecturename = "Second Lecture"
                        }
                };
            lecture.ForEach(l => ctx.Lectures.Add(l));
            ctx.SaveChanges();

            var videos = new List<Video>
                {
                    new Video
                        {
                            Lecture = lecture[0],
                            LectureId = lecture[0].Id,
                            Name = "Video from first Lecture",
                            Url = "http://youtu.be/nTFEUsudhfs"
                        },
                    new Video
                        {
                            Lecture = lecture[1],
                            LectureId = lecture[1].Id,
                            Name = "Video from second lecture",
                            Url = "http://www.youtube.com/watch?v=jiUKpX09zo4"
                        }
                };
            videos.ForEach(v => ctx.Videos.Add(v));
            ctx.SaveChanges();

            var comment = new List<Comment>
                {
                    new Comment
                        {
                            CommentText = "This is comment 1",
                            Lecture = lecture[0],
                            LectureId = lecture[0].Id,
                        },
                    new Comment
                        {
                            CommentText = "This is comment 2",
                            Lecture = lecture[1],
                            LectureId = lecture[1].Id,
                        }
                };
            comment.ForEach(c => ctx.Comments.Add(c));
            ctx.SaveChanges();
        }
    }
}
