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
    public class WelnessesController : ApiController
    {
        private ihbiprojectDBEntities db = new ihbiprojectDBEntities();

        // GET: api/Welnesses
        public IQueryable<Welness> GetWelnesses()
        {
            return db.Welnesses;
        }

        // GET: api/Welnesses/5
        [ResponseType(typeof(Welness))]
        public IHttpActionResult GetWelness(int id)
        {
            Welness welness = db.Welnesses.Find(id);
            if (welness == null)
            {
                return NotFound();
            }

            return Ok(welness);
        }

        // PUT: api/Welnesses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWelness(int id, Welness welness)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != welness.Id)
            {
                return BadRequest();
            }

            db.Entry(welness).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WelnessExists(id))
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

        // POST: api/Welnesses
        [ResponseType(typeof(Welness))]
        public IHttpActionResult PostWelness(Welness welness)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Welnesses.Add(welness);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = welness.Id }, welness);
        }

        // DELETE: api/Welnesses/5
        [ResponseType(typeof(Welness))]
        public IHttpActionResult DeleteWelness(int id)
        {
            Welness welness = db.Welnesses.Find(id);
            if (welness == null)
            {
                return NotFound();
            }

            db.Welnesses.Remove(welness);
            db.SaveChanges();

            return Ok(welness);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WelnessExists(int id)
        {
            return db.Welnesses.Count(e => e.Id == id) > 0;
        }
    }
}