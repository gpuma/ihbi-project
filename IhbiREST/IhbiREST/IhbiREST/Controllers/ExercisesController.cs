﻿using System;
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
    public class ExercisesController : ApiController
    {
        private ihbiprojectDBEntities db = new ihbiprojectDBEntities();

        // GET: api/Exercises
        public IQueryable<Exercise> GetExercises()
        {
            return db.Exercises;
        }

        // GET: api/Exercises/5
        [ResponseType(typeof(Exercise))]
        public IHttpActionResult GetExercise(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        // PUT: api/Exercises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExercise(int id, Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise.Id)
            {
                return BadRequest();
            }

            db.Entry(exercise).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id))
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

        // POST: api/Exercises
        [ResponseType(typeof(Exercise))]
        public IHttpActionResult PostExercise(Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exercises.Add(exercise);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ExerciseExists(exercise.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = exercise.Id }, exercise);
        }

        // DELETE: api/Exercises/5
        [ResponseType(typeof(Exercise))]
        public IHttpActionResult DeleteExercise(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return NotFound();
            }

            db.Exercises.Remove(exercise);
            db.SaveChanges();

            return Ok(exercise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseExists(int id)
        {
            return db.Exercises.Count(e => e.Id == id) > 0;
        }
    }
}