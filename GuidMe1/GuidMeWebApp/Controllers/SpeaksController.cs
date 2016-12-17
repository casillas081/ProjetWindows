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
    public class SpeaksController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Speaks
        public IQueryable<Speak> GetSpeaks()
        {
            return db.Speaks;
        }

        // GET: api/Speaks/5
        [ResponseType(typeof(Speak))]
        public async Task<IHttpActionResult> GetSpeak(int id)
        {
            Speak speak = await db.Speaks.FindAsync(id);
            if (speak == null)
            {
                return NotFound();
            }

            return Ok(speak);
        }

        // PUT: api/Speaks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSpeak(int id, Speak speak)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != speak.IdSpeak)
            {
                return BadRequest();
            }

            db.Entry(speak).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeakExists(id))
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

        // POST: api/Speaks
        [ResponseType(typeof(Speak))]
        public async Task<IHttpActionResult> PostSpeak(Speak speak)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Speaks.Add(speak);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = speak.IdSpeak }, speak);
        }

        // DELETE: api/Speaks/5
        [ResponseType(typeof(Speak))]
        public async Task<IHttpActionResult> DeleteSpeak(int id)
        {
            Speak speak = await db.Speaks.FindAsync(id);
            if (speak == null)
            {
                return NotFound();
            }

            db.Speaks.Remove(speak);
            await db.SaveChangesAsync();

            return Ok(speak);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpeakExists(int id)
        {
            return db.Speaks.Count(e => e.IdSpeak == id) > 0;
        }
    }
}