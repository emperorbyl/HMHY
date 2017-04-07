using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

using hmhyWebservice2._0.Models;
using hmhyWebservice2._0.DAL;
using System.Web.Http.Cors;
using System.Xml;
using System.Xml.Serialization;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace hmhyWebservice2._0.Controllers
{
    [EnableCors("*", "*", "GET,POST,PUT,DELETE")]
    [RoutePrefix("api/MainUser")]
    public class MainUserController : ApiController
    {
        private HmhyGlobalDbContext db = new HmhyGlobalDbContext();

        // GET: api/MainUser
        [Route("")]
        public IQueryable<MainUser> GetMainUsers()
        {
            return db.MainUser;
        }

        // GET: api/MainUser/5
        [Route("{id:int}")]
        [ResponseType(typeof(MainUser))]
        public IHttpActionResult GetMainUser(int id)
        {
            MainUser mainUser = db.MainUser.Find(id);
            if (mainUser == null)
            {
                return NotFound();
            }

            return Ok(mainUser);
        }

        // PUT: api/MainUsers/5
        [HttpPut]
        [Route("")]
        public IHttpActionResult ReturnXmlDocument(HttpRequestMessage request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(request == null)
            {
                return BadRequest("Null request");
            }

            var doc = new XmlDocument();
            var ser = new XmlSerializer(typeof(MainUser));
            var user = new MainUser();

            try
            {
                 user = (MainUser)ser.Deserialize(request.Content.ReadAsStreamAsync().Result);
            }
            catch(Exception e)
            {
                return BadRequest("Error parsing object. Stack Trace: " + e.StackTrace);
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainUserExists(user.userId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(user);

        }
       

        // POST: api/MainUsers
        [HttpPost]
        [Route("")]
        public IHttpActionResult PostMainUser(HttpRequestMessage request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (request == null)
            {
                return BadRequest("Null request");
            }

            var doc = new XmlDocument();
            var ser = new XmlSerializer(typeof(MainUser));
            var user = new MainUser();

            try
            {
                user = (MainUser)ser.Deserialize(request.Content.ReadAsStreamAsync().Result);
            }
            catch (Exception e)
            {
                return BadRequest("Error parsing object. Stack Trace: " + e.StackTrace);
            }

            var userExists = db.MainUser.Find(user.userId);
            if(userExists != null)
            {
                return BadRequest("Record already exists");
            }

            

            db.MainUser.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.userId }, user);
        }

        //// DELETE: api/MainUsers/5
        //[ResponseType(typeof(MainUser))]
        //public IHttpActionResult DeleteMainUser(int id)
        //{
        //    MainUser mainUser = db.MainUser.Find(id);
        //    if (mainUser == null)
        //    {
        //        return NotFound();
        //    }

        //    db.MainUser.Remove(mainUser);
        //    db.SaveChanges();

        //    return Ok(mainUser);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MainUserExists(int id)
        {
            return db.MainUser.Count(e => e.userId == id) > 0;
        }
    }
}