using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GuidMeWebApp.Models;

namespace GuidMeWebApp.Controllers
{
    public class TranslationPlacesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TranslationPlaces
        public IQueryable<TranslationPlace> GetTranslationPlaces()
        {
            return db.TranslationPlaces;
        }

        // GET: api/TranslationPlaces/5
        [ResponseType(typeof(TranslationPlace))]
        public async Task<IHttpActionResult> GetTranslationPlace(int id)
        {
            TranslationPlace translationPlace = await db.TranslationPlaces.FindAsync(id);
            if (translationPlace == null)
            {
                return NotFound();
            }

            return Ok(translationPlace);
        }

        // PUT: api/TranslationPlaces/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTranslationPlace(int id, TranslationPlace translationPlace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != translationPlace.IdTranslationPlace)
            {
                return BadRequest();
            }

            db.Entry(translationPlace).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostTranslationPlace(TranslationPlace translationPlace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TranslationPlaces.Add(translationPlace);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = translationPlace.IdTranslationPlace }, translationPlace);
        }

        // DELETE: api/TranslationPlaces/5
        [ResponseType(typeof(TranslationPlace))]
        public async Task<IHttpActionResult> DeleteTranslationPlace(int id)
        {
            TranslationPlace translationPlace = await db.TranslationPlaces.FindAsync(id);
            if (translationPlace == null)
            {
                return NotFound();
            }

            db.TranslationPlaces.Remove(translationPlace);
            await db.SaveChangesAsync();

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
            return db.TranslationPlaces.Count(e => e.IdTranslationPlace == id) > 0;
        }
    }
}