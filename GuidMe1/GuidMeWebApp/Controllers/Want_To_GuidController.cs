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
using System.Data.Entity.Spatial;

namespace GuidMeWebApp.Controllers
{
    public class Want_To_GuidController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Want_To_Guid
        public IQueryable<Want_To_Guid> GetWant_To_Guid()
        {
            return db.Want_To_Guid;
        }

        // GET: api/Want_To_Guid/5
        [ResponseType(typeof(Want_To_Guid))]
        public async Task<IHttpActionResult> GetWant_To_Guid(int id)
        {
            Want_To_Guid want_To_Guid = await db.Want_To_Guid.FindAsync(id);
            if (want_To_Guid == null)
            {
                return NotFound();
            }

            return Ok(want_To_Guid);
        }

        // PUT: api/Want_To_Guid/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWant_To_Guid(int id, Want_To_Guid want_To_Guid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != want_To_Guid.IdWantToGuid)
            {
                return BadRequest();
            }

            db.Entry(want_To_Guid).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Want_To_GuidExists(id))
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

        // POST: api/Want_To_Guid
        [ResponseType(typeof(Want_To_Guid))]
        public async Task<IHttpActionResult> PostWant_To_Guid(Want_To_GuidCreateModel want_To_Guid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = User.Identity as ClaimsIdentity;
            Claim identitytClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            ApplicationUser user = db.Users.FirstOrDefault(u => u.Id == identitytClaim.Value);
            Want_To_Guid wtg = new Want_To_Guid();
            var pointString = string.Format("POINT({0} {1})", want_To_Guid.Position.Longitude, want_To_Guid.Position.Latitude);
            DbGeography geo = DbGeography.PointFromText(pointString, 4326);
            wtg.Place = new Place() { IdPlace = want_To_Guid.Id, Address = want_To_Guid.Address, Position = geo };
            wtg.Person = user;
            db.Want_To_Guid.Add(wtg);
            await db.SaveChangesAsync();

            return Created("api/Want_To_Guid", wtg);
        }

        // DELETE: api/Want_To_Guid/5
        [ResponseType(typeof(Want_To_Guid))]
        public async Task<IHttpActionResult> DeleteWant_To_Guid(int id)
        {
            Want_To_Guid want_To_Guid = await db.Want_To_Guid.FindAsync(id);
            if (want_To_Guid == null)
            {
                return NotFound();
            }

            db.Want_To_Guid.Remove(want_To_Guid);
            await db.SaveChangesAsync();

            return Ok(want_To_Guid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Want_To_GuidExists(int id)
        {
            return db.Want_To_Guid.Count(e => e.IdWantToGuid == id) > 0;
        }
    }
}