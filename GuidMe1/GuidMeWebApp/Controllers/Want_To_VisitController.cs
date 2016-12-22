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
using System.Security.Claims;

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
        public async Task<IHttpActionResult> PostWant_To_Visit(Want_To_VisitCreateModel want_To_Visit)
        {
            f(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = User.Identity as ClaimsIdentity;
            Claim identitytClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            ApplicationUser user = db.Users.FirstOrDefault(u => u.Id == identitytClaim.Value);
            Want_To_Visit wtg = new Want_To_Visit();
            /*var pointString = string.Format("POINT({0} {1})", want_To_Guid.Position.Longitude, want_To_Guid.Position.Latitude);
            DbGeography geo = DbGeography.PointFromText(pointString, 4326);*/
            wtg.place = new Place() { IdPlace = want_To_Visit.Id, Address = want_To_Visit.Address /*Position = geo*/ };
            wtg.person = user;
            db.Want_To_Visit.Add(wtg);
            await db.SaveChangesAsync();

            return Created("api/Want_To_Visit", wtg);
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