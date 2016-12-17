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
    public class MatchVisitorGuidesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MatchVisitorGuides
        public IQueryable<MatchVisitorGuide> GetMatchVisitorGuides()
        {
            return db.MatchVisitorGuides;
        }

        // GET: api/MatchVisitorGuides/5
        [ResponseType(typeof(MatchVisitorGuide))]
        public async Task<IHttpActionResult> GetMatchVisitorGuide(int id)
        {
            MatchVisitorGuide matchVisitorGuide = await db.MatchVisitorGuides.FindAsync(id);
            if (matchVisitorGuide == null)
            {
                return NotFound();
            }

            return Ok(matchVisitorGuide);
        }

        // PUT: api/MatchVisitorGuides/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMatchVisitorGuide(int id, MatchVisitorGuide matchVisitorGuide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != matchVisitorGuide.IdMatchVisitorGuide)
            {
                return BadRequest();
            }

            db.Entry(matchVisitorGuide).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchVisitorGuideExists(id))
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

        // POST: api/MatchVisitorGuides
        [ResponseType(typeof(MatchVisitorGuide))]
        public async Task<IHttpActionResult> PostMatchVisitorGuide(MatchVisitorGuide matchVisitorGuide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MatchVisitorGuides.Add(matchVisitorGuide);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = matchVisitorGuide.IdMatchVisitorGuide }, matchVisitorGuide);
        }

        // DELETE: api/MatchVisitorGuides/5
        [ResponseType(typeof(MatchVisitorGuide))]
        public async Task<IHttpActionResult> DeleteMatchVisitorGuide(int id)
        {
            MatchVisitorGuide matchVisitorGuide = await db.MatchVisitorGuides.FindAsync(id);
            if (matchVisitorGuide == null)
            {
                return NotFound();
            }

            db.MatchVisitorGuides.Remove(matchVisitorGuide);
            await db.SaveChangesAsync();

            return Ok(matchVisitorGuide);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MatchVisitorGuideExists(int id)
        {
            return db.MatchVisitorGuides.Count(e => e.IdMatchVisitorGuide == id) > 0;
        }
    }
}