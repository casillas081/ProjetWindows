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
using GuidMeClassLibrary;

namespace WebApiGuidMe.Controllers
{
    public class PlacesController : ApiController
    {
        private GuidMeContext db = new GuidMeContext();

        // GET: api/Places
        public IQueryable<Place> GetPlaces()
        {
            return db.Places;
        }

        // GET: api/Places/5
        [ResponseType(typeof(Place))]
        public IHttpActionResult GetPlace(string id)
        {
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return NotFound();
            }

            return Ok(place);
        }

        // PUT: api/Places/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlace(string id, Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != place.IdPlace)
            {
                return BadRequest();
            }

            db.Entry(place).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceExists(id))
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

        // POST: api/Places
        [ResponseType(typeof(Place))]
        public IHttpActionResult PostPlace(Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Places.Add(place);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PlaceExists(place.IdPlace))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = place.IdPlace }, place);
        }

        // DELETE: api/Places/5
        [ResponseType(typeof(Place))]
        public IHttpActionResult DeletePlace(string id)
        {
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return NotFound();
            }

            db.Places.Remove(place);
            db.SaveChanges();

            return Ok(place);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlaceExists(string id)
        {
            return db.Places.Count(e => e.IdPlace == id) > 0;
        }
    }
}