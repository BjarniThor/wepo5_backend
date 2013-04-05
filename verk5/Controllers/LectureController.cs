using System;
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
    public class LectureController : ApiController
    {
        private verk5Context db = new verk5Context();

        // GET api/Lecture
        public IEnumerable<Lecture> GetLectures()
        {
            var lectures = db.Lectures.Include(l => l.Course);
            return lectures.AsEnumerable();
        }

        // GET api/Lecture/5
        public Lecture GetLecture(int id)
        {
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return lecture;
        }

        // PUT api/Lecture/5
        public HttpResponseMessage PutLecture(int id, Lecture lecture)
        {
            if (ModelState.IsValid && id == lecture.Id)
            {
                db.Entry(lecture).State = EntityState.Modified;

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

        // POST api/Lecture
        public HttpResponseMessage PostLecture(Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.Lectures.Add(lecture);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, lecture);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = lecture.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Lecture/5
        public HttpResponseMessage DeleteLecture(int id)
        {
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Lectures.Remove(lecture);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, lecture);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}