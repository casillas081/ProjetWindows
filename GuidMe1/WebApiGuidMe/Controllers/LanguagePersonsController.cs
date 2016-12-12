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
    public class LanguagePersonsController : ApiController
    {
        private GuidMeContext db = new GuidMeContext();

        // GET: api/LanguagePersons
        public IQueryable<LanguagePerson> GetLanguagePersons()
        {
            return db.LanguagePersons;
        }

        // GET: api/LanguagePersons/5
        [ResponseType(typeof(LanguagePerson))]
        public IHttpActionResult GetLanguagePerson(string id)
        {
            LanguagePerson languagePerson = db.LanguagePersons.Find(id);
            if (languagePerson == null)
            {
                return NotFound();
            }

            return Ok(languagePerson);
        }

        // PUT: api/LanguagePersons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLanguagePerson(string id, LanguagePerson languagePerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != languagePerson.CodeLanguage)
            {
                return BadRequest();
            }

            db.Entry(languagePerson).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguagePersonExists(id))
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

        // POST: api/LanguagePersons
        [ResponseType(typeof(LanguagePerson))]
        public IHttpActionResult PostLanguagePerson(LanguagePerson languagePerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LanguagePersons.Add(languagePerson);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LanguagePersonExists(languagePerson.CodeLanguage))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = languagePerson.CodeLanguage }, languagePerson);
        }

        // DELETE: api/LanguagePersons/5
        [ResponseType(typeof(LanguagePerson))]
        public IHttpActionResult DeleteLanguagePerson(string id)
        {
            LanguagePerson languagePerson = db.LanguagePersons.Find(id);
            if (languagePerson == null)
            {
                return NotFound();
            }

            db.LanguagePersons.Remove(languagePerson);
            db.SaveChanges();

            return Ok(languagePerson);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LanguagePersonExists(string id)
        {
            return db.LanguagePersons.Count(e => e.CodeLanguage == id) > 0;
        }
    }
}