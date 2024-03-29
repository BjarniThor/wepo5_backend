﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using verk5.Models;

namespace verk5.Controllers
{
    public class CourseController : ApiController
    {
        private verk5Context db = new verk5Context();

        private IQueryable<CourseDTO.Course> MapCourses()
        {
            var courses = db.Courses.Select(c => new CourseDTO.Course()
                {
                    CourseId = c.Id,
                    Coursename = c.Coursename
                });
            if (courses == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            return courses;
        }

        // GET api/Course
        public CourseDTO GetCourses()
        {
            //var courses = db.Courses.AsEnumerable();
            var courses = new CourseDTO()
                {
                    Courses = MapCourses().AsEnumerable()
                };
            if (courses == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            return courses;
        }

        // GET api/Course/5
        /// <summary>
        /// Not fully implemented since not really needed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Course GetCourse(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return course;
        }

        // PUT api/Course/5
        public HttpResponseMessage PutCourse(int id, Course course)
        {
            if (ModelState.IsValid && id == course.Id)
            {
                db.Entry(course).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Course
        [Authorize(Roles = "Teacher")]
        public HttpResponseMessage PostCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, course);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = course.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Course/5
        public HttpResponseMessage DeleteCourse(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Courses.Remove(course);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, course);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}