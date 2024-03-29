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
using Verkvaki.Helpers;
using verk5.Models;

namespace verk5.Controllers
{
    public class VideoController : ApiController
    {
        private verk5Context db = new verk5Context();

        // GET api/Video
        public IEnumerable<Video> GetVideos()
        {
            var videos = db.Videos.Include(v => v.Lecture);
            return videos.AsEnumerable();
        }

        // GET api/Video/5
        public Video GetVideo(int id)
        {
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return video;
        }

        // PUT api/Video/5
        public HttpResponseMessage PutVideo(int id, Video video)
        {
            if (ModelState.IsValid && id == video.Id)
            {
                db.Entry(video).State = EntityState.Modified;

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

        // POST api/Video
        [HttpPost]
        [AllowCrossSiteJson]
        public HttpResponseMessage PostVideo(Video video)
        {
            if (ModelState.IsValid)
            {
                db.Videos.Add(video);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, video);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = video.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Video/5
        public HttpResponseMessage DeleteVideo(int id)
        {
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Videos.Remove(video);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, video);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}