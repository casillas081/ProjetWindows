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
        public async Task<IHttpActionResult> PostWant_To_Guid(Want_To_Guid want_To_Guid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Want_To_Guid.Add(want_To_Guid);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = want_To_Guid.IdWantToGuid }, want_To_Guid);
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