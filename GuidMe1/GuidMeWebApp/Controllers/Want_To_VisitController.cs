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
    public class Want_To_VisitController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Want_To_Visit
        public IQueryable<Want_To_Visit> GetWant_To_Visit()
        {
            return db.Want_To_Visit;
        }

        // GET: api/Want_To_Visit/5
        [ResponseType(typeof(Want_To_Visit))]
        public async Task<IHttpActionResult> GetWant_To_Visit(int id)
        {
            Want_To_Visit want_To_Visit = await db.Want_To_Visit.FindAsync(id);
            if (want_To_Visit == null)
            {
                return NotFound();
            }

            return Ok(want_To_Visit);
        }

        // PUT: api/Want_To_Visit/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWant_To_Visit(int id, Want_To_Visit want_To_Visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != want_To_Visit.IdWantToVisit)
            {
                return BadRequest();
            }

            db.Entry(want_To_Visit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Want_To_VisitExists(id))
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

        // POST: api/Want_To_Visit
        [ResponseType(typeof(Want_To_Visit))]
        public async Task<IHttpActionResult> PostWant_To_Visit(Want_To_Visit want_To_Visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Want_To_Visit.Add(want_To_Visit);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = want_To_Visit.IdWantToVisit }, want_To_Visit);
        }

        // DELETE: api/Want_To_Visit/5
        [ResponseType(typeof(Want_To_Visit))]
        public async Task<IHttpActionResult> DeleteWant_To_Visit(int id)
        {
            Want_To_Visit want_To_Visit = await db.Want_To_Visit.FindAsync(id);
            if (want_To_Visit == null)
            {
                return NotFound();
            }

            db.Want_To_Visit.Remove(want_To_Visit);
            await db.SaveChangesAsync();

            return Ok(want_To_Visit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Want_To_VisitExists(int id)
        {
            return db.Want_To_Visit.Count(e => e.IdWantToVisit == id) > 0;
        }
    }
}