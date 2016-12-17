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
    public class Translation_NationalityController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Translation_Nationality
        public IQueryable<Translation_Nationality> GetTranslation_Nationality()
        {
            return db.Translation_Nationality;
        }

        // GET: api/Translation_Nationality/5
        [ResponseType(typeof(Translation_Nationality))]
        public async Task<IHttpActionResult> GetTranslation_Nationality(int id)
        {
            Translation_Nationality translation_Nationality = await db.Translation_Nationality.FindAsync(id);
            if (translation_Nationality == null)
            {
                return NotFound();
            }

            return Ok(translation_Nationality);
        }

        // PUT: api/Translation_Nationality/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTranslation_Nationality(int id, Translation_Nationality translation_Nationality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != translation_Nationality.IdTranslationNationality)
            {
                return BadRequest();
            }

            db.Entry(translation_Nationality).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Translation_NationalityExists(id))
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

        // POST: api/Translation_Nationality
        [ResponseType(typeof(Translation_Nationality))]
        public async Task<IHttpActionResult> PostTranslation_Nationality(Translation_Nationality translation_Nationality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Translation_Nationality.Add(translation_Nationality);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = translation_Nationality.IdTranslationNationality }, translation_Nationality);
        }

        // DELETE: api/Translation_Nationality/5
        [ResponseType(typeof(Translation_Nationality))]
        public async Task<IHttpActionResult> DeleteTranslation_Nationality(int id)
        {
            Translation_Nationality translation_Nationality = await db.Translation_Nationality.FindAsync(id);
            if (translation_Nationality == null)
            {
                return NotFound();
            }

            db.Translation_Nationality.Remove(translation_Nationality);
            await db.SaveChangesAsync();

            return Ok(translation_Nationality);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Translation_NationalityExists(int id)
        {
            return db.Translation_Nationality.Count(e => e.IdTranslationNationality == id) > 0;
        }
    }
}