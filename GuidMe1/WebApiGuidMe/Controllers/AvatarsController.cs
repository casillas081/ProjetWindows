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
using WebApiGuidMe.Models;

namespace WebApiGuidMe.Controllers
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
        public IHttpActionResult GetAvatar(string id)
        {
            Avatar avatar = db.Avatars.Find(id);
            if (avatar == null)
            {
                return NotFound();
            }

            return Ok(avatar);
        }

        // PUT: api/Avatars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAvatar(string id, Avatar avatar)
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
                db.SaveChanges();
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
        public IHttpActionResult PostAvatar(Avatar avatar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Avatars.Add(avatar);

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult DeleteAvatar(string id)
        {
            Avatar avatar = db.Avatars.Find(id);
            if (avatar == null)
            {
                return NotFound();
            }

            db.Avatars.Remove(avatar);
            db.SaveChanges();

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