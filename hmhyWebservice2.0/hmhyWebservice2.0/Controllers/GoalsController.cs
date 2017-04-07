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
    [RoutePrefix("api/Goal")]
    public class GoalsController : ApiController
    {
        private hmhyGlobalDbEntities1 db = new hmhyGlobalDbEntities1();

        // GET: api/Goals
        [Route("")]
        public IQueryable<Goal> GetGoals()
        {
            return db.Goals;
        }

        // GET: api/Goals/5
        [Route("{id:int}")]
        [ResponseType(typeof(Goal))]
        public IHttpActionResult GetGoal(int id)
        {
            try
            {
                Goal goal = db.Goals.Find(id);
                if (goal == null)
                {
                    return NotFound();
                }
                return Ok(goal);
            }
            catch (Exception e) { return BadRequest(e.Message); }

            return Ok();
            
        }

        // PUT: api/Goals/5
        [HttpPut]
        [Route("")]
        public IHttpActionResult PutGoal(HttpRequestMessage request)
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
            var ser = new XmlSerializer(typeof(Goal));
            var goal = new Goal();

            try
            {
                goal = (Goal)ser.Deserialize(request.Content.ReadAsStreamAsync().Result);
            }
            catch (Exception e)
            {
                return BadRequest("Error parsing object. Stack Trace: " + e.StackTrace);
            }

            db.Entry(goal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalExists(goal.goalId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(goal);

        }

        // POST: api/Goals
        [HttpPost]
        [Route("")]
        public IHttpActionResult PostGoal(HttpRequestMessage request)
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
            var ser = new XmlSerializer(typeof(Goal));
            var goal = new Goal();

            try
            {
                goal = (Goal)ser.Deserialize(request.Content.ReadAsStreamAsync().Result);
            }
            catch (Exception e)
            {
                return BadRequest("Error parsing object. Stack Trace: " + e.StackTrace);
            }

            var goalExists = db.Goals.Find(goal.goalId);
            if (goalExists != null)
            {
                return BadRequest("Record already exists");
            }



            db.Goals.Add(goal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = goal.goalId }, goal);
        }

        //// DELETE: api/Goals/5
        //[ResponseType(typeof(Goal))]
        //public IHttpActionResult DeleteGoal(int id)
        //{
        //    Goal goal = db.Goals.Find(id);
        //    if (goal == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Goals.Remove(goal);
        //    db.SaveChanges();

        //    return Ok(goal);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool GoalExists(int id)
        {
            return db.Goals.Count(e => e.goalId == id) > 0;
        }
    }
}