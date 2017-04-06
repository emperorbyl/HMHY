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

namespace hmhyWebservice2._0.Controllers
{
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
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMainUser(int id, MainUser mainUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mainUser.userId)
            {
                return BadRequest();
            }

            db.Entry(mainUser).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                if (!MainUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MainUsers
        [ResponseType(typeof(MainUser))]
        public IHttpActionResult PostMainUser(MainUser mainUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MainUser.Add(mainUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mainUser.userId }, mainUser);
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