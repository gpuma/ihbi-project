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
    public class Exercise_TypeController : ApiController
    {
        private ihbiprojectDBEntities db = new ihbiprojectDBEntities();

        // GET: api/Exercise_Type
        public IQueryable<Exercise_Type> GetExercise_Type()
        {
            return db.Exercise_Type;
        }

        // GET: api/Exercise_Type/5
        [ResponseType(typeof(Exercise_Type))]
        public IHttpActionResult GetExercise_Type(int id)
        {
            Exercise_Type exercise_Type = db.Exercise_Type.Find(id);
            if (exercise_Type == null)
            {
                return NotFound();
            }

            return Ok(exercise_Type);
        }

        // PUT: api/Exercise_Type/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExercise_Type(int id, Exercise_Type exercise_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise_Type.Id)
            {
                return BadRequest();
            }

            db.Entry(exercise_Type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exercise_TypeExists(id))
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

        // POST: api/Exercise_Type
        [ResponseType(typeof(Exercise_Type))]
        public IHttpActionResult PostExercise_Type(Exercise_Type exercise_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exercise_Type.Add(exercise_Type);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exercise_Type.Id }, exercise_Type);
        }

        // DELETE: api/Exercise_Type/5
        [ResponseType(typeof(Exercise_Type))]
        public IHttpActionResult DeleteExercise_Type(int id)
        {
            Exercise_Type exercise_Type = db.Exercise_Type.Find(id);
            if (exercise_Type == null)
            {
                return NotFound();
            }

            db.Exercise_Type.Remove(exercise_Type);
            db.SaveChanges();

            return Ok(exercise_Type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Exercise_TypeExists(int id)
        {
            return db.Exercise_Type.Count(e => e.Id == id) > 0;
        }
    }
}