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
    public class ConsumablesController : ApiController
    {
        private ihbiprojectDBEntities db = new ihbiprojectDBEntities();

        // GET: api/Consumables
        public IQueryable<Consumable> GetConsumables()
        {
            return db.Consumables;
        }

        // GET: api/Consumables/5
        [ResponseType(typeof(Consumable))]
        public IHttpActionResult GetConsumable(int id)
        {
            Consumable consumable = db.Consumables.Find(id);
            if (consumable == null)
            {
                return NotFound();
            }

            return Ok(consumable);
        }

        //GET api/Consumables/5/2011-12-30
        [Route("api/Consumables/{user_id}/{date}")]
        [HttpGet]
        public IHttpActionResult GetLastConsumable(String user_id, String date)
        {

            var dateT = DateTime.Parse(date);
            var id = int.Parse(user_id);
            var consumable = (from c in db.Consumables
                            where (c.user_id == id) && (c.date == dateT)
                            orderby c.Id descending
                            select c).FirstOrDefault();
            if (consumable == null)
            {
                return NotFound();
            }

            return Ok(consumable);

        }

        // PUT: api/Consumables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConsumable(int id, Consumable consumable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consumable.Id)
            {
                return BadRequest();
            }

            db.Entry(consumable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumableExists(id))
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

        // POST: api/Consumables
        [ResponseType(typeof(Consumable))]
        public IHttpActionResult PostConsumable(Consumable consumable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Consumables.Add(consumable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = consumable.Id }, consumable);
        }

        // DELETE: api/Consumables/5
        [ResponseType(typeof(Consumable))]
        public IHttpActionResult DeleteConsumable(int id)
        {
            Consumable consumable = db.Consumables.Find(id);
            if (consumable == null)
            {
                return NotFound();
            }

            db.Consumables.Remove(consumable);
            db.SaveChanges();

            return Ok(consumable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsumableExists(int id)
        {
            return db.Consumables.Count(e => e.Id == id) > 0;
        }
    }
}