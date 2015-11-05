using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using IhbiREST.Models;

namespace IhbiREST.Controllers
{
    public class Exercise2Controller : ApiController
    {
        private ihbiprojectDBEntities db = new ihbiprojectDBEntities();

        // GET: api/Exercise2
        public IQueryable<Exercise2> GetExercise2()
        {
            return db.Exercise2;
        }

        // GET: api/Exercise2/5
        [ResponseType(typeof(Exercise2))]
        public IHttpActionResult GetExercise2(int id)
        {
            Exercise2 exercise2 = db.Exercise2.Find(id);
            if (exercise2 == null)
            {
                return NotFound();
            }

            return Ok(exercise2);
        }

        // PUT: api/Exercise2/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExercise2(int id, Exercise2 exercise2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise2.user_id)
            {
                return BadRequest();
            }

            db.Entry(exercise2).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exercise2Exists(id))
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

        // POST: api/Exercise2
        [ResponseType(typeof(Exercise2))]
        public IHttpActionResult PostExercise2(Exercise2 exercise2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exercise2.Add(exercise2);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Exercise2Exists(exercise2.user_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = exercise2.user_id }, exercise2);
        }

        // DELETE: api/Exercise2/5
        [ResponseType(typeof(Exercise2))]
        public IHttpActionResult DeleteExercise2(int id)
        {
            Exercise2 exercise2 = db.Exercise2.Find(id);
            if (exercise2 == null)
            {
                return NotFound();
            }

            db.Exercise2.Remove(exercise2);
            db.SaveChanges();

            return Ok(exercise2);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Exercise2Exists(int id)
        {
            return db.Exercise2.Count(e => e.user_id == id) > 0;
        }
    }
}