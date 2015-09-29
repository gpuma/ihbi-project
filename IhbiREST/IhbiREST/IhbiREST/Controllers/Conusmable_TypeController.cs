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
    public class Conusmable_TypeController : ApiController
    {
        private ihbiprojectDBEntities db = new ihbiprojectDBEntities();

        // GET: api/Conusmable_Type
        public IQueryable<Conusmable_Type> GetConusmable_Type()
        {
            return db.Conusmable_Type;
        }

        // GET: api/Conusmable_Type/5
        [ResponseType(typeof(Conusmable_Type))]
        public IHttpActionResult GetConusmable_Type(int id)
        {
            Conusmable_Type conusmable_Type = db.Conusmable_Type.Find(id);
            if (conusmable_Type == null)
            {
                return NotFound();
            }

            return Ok(conusmable_Type);
        }

        // PUT: api/Conusmable_Type/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConusmable_Type(int id, Conusmable_Type conusmable_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conusmable_Type.Id)
            {
                return BadRequest();
            }

            db.Entry(conusmable_Type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Conusmable_TypeExists(id))
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

        // POST: api/Conusmable_Type
        [ResponseType(typeof(Conusmable_Type))]
        public IHttpActionResult PostConusmable_Type(Conusmable_Type conusmable_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Conusmable_Type.Add(conusmable_Type);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = conusmable_Type.Id }, conusmable_Type);
        }

        // DELETE: api/Conusmable_Type/5
        [ResponseType(typeof(Conusmable_Type))]
        public IHttpActionResult DeleteConusmable_Type(int id)
        {
            Conusmable_Type conusmable_Type = db.Conusmable_Type.Find(id);
            if (conusmable_Type == null)
            {
                return NotFound();
            }

            db.Conusmable_Type.Remove(conusmable_Type);
            db.SaveChanges();

            return Ok(conusmable_Type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Conusmable_TypeExists(int id)
        {
            return db.Conusmable_Type.Count(e => e.Id == id) > 0;
        }
    }
}