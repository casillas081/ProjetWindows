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
    public class TranslationPlacesController : ApiController
    {
        private GuidMeContext db = new GuidMeContext();

        // GET: api/TranslationPlaces
        public IEnumerable<TranslationPlace> GetTranslationPlaces()
        {
            return db.TranslationPlaces.ToList();
        }

        // GET: api/TranslationPlaces/5
        [ResponseType(typeof(TranslationPlace))]
        public IHttpActionResult GetTranslationPlace(int id)
        {
            TranslationPlace translationPlace = db.TranslationPlaces.Find(id);
            if (translationPlace == null)
            {
                return NotFound();
            }

            return Ok(translationPlace);
        }

        // PUT: api/TranslationPlaces/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTranslationPlace(int id, TranslationPlace translationPlace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != translationPlace.IdTraslationPlace)
            {
                return BadRequest();
            }

            db.Entry(translationPlace).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TranslationPlaceExists(id))
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

        // POST: api/TranslationPlaces
        [ResponseType(typeof(TranslationPlace))]
        public IHttpActionResult PostTranslationPlace(TranslationPlace translationPlace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TranslationPlaces.Add(translationPlace);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = translationPlace.IdTraslationPlace }, translationPlace);
        }

        // DELETE: api/TranslationPlaces/5
        [ResponseType(typeof(TranslationPlace))]
        public IHttpActionResult DeleteTranslationPlace(int id)
        {
            TranslationPlace translationPlace = db.TranslationPlaces.Find(id);
            if (translationPlace == null)
            {
                return NotFound();
            }

            db.TranslationPlaces.Remove(translationPlace);
            db.SaveChanges();

            return Ok(translationPlace);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TranslationPlaceExists(int id)
        {
            return db.TranslationPlaces.Count(e => e.IdTraslationPlace == id) > 0;
        }
    }
}