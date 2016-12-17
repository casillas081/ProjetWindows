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
    public class AvatarsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Avatars
        public IQueryable<Avatar> GetAvatars()
        {
            return db.Avatars;
        }

        // GET: api/Avatars/5
        [ResponseType(typeof(Avatar))]
        public async Task<IHttpActionResult> GetAvatar(string id)
        {
            Avatar avatar = await db.Avatars.FindAsync(id);
            if (avatar == null)
            {
                return NotFound();
            }

            return Ok(avatar);
        }

        // PUT: api/Avatars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAvatar(string id, Avatar avatar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != avatar.IdPicture)
            {
                return BadRequest();
            }

            db.Entry(avatar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvatarExists(id))
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

        // POST: api/Avatars
        [ResponseType(typeof(Avatar))]
        public async Task<IHttpActionResult> PostAvatar(Avatar avatar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Avatars.Add(avatar);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AvatarExists(avatar.IdPicture))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = avatar.IdPicture }, avatar);
        }

        // DELETE: api/Avatars/5
        [ResponseType(typeof(Avatar))]
        public async Task<IHttpActionResult> DeleteAvatar(string id)
        {
            Avatar avatar = await db.Avatars.FindAsync(id);
            if (avatar == null)
            {
                return NotFound();
            }

            db.Avatars.Remove(avatar);
            await db.SaveChangesAsync();

            return Ok(avatar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AvatarExists(string id)
        {
            return db.Avatars.Count(e => e.IdPicture == id) > 0;
        }
    }
}