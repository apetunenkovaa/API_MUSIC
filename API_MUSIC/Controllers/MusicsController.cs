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
using API_MUSIC.Models;

namespace API_MUSIC.Controllers
{
    public class MusicsController : ApiController
    {
        private Petunenkova_Project_SQLEntities db = new Petunenkova_Project_SQLEntities();

        // GET: api/Musics
        [ResponseType(typeof(List<MusicModel>))]
        public IHttpActionResult GetMusic()
        {
            return Ok(db.Music.ToList().ConvertAll(x => new MusicModel(x)));
        }

        // GET: api/Musics/5
        [ResponseType(typeof(Music))]
        public IHttpActionResult GetMusic(int id)
        {
            Music music = db.Music.Find(id);
            if (music == null)
            {
                return NotFound();
            }

            return Ok(music);
        }

        // PUT: api/Musics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMusic(int id, Music music)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != music.ID_Music)
            {
                return BadRequest();
            }

            db.Entry(music).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicExists(id))
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

        // POST: api/Musics
        [ResponseType(typeof(Music))]
        public IHttpActionResult PostMusic(Music music)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Music.Add(music);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = music.ID_Music }, music);
        }

        // DELETE: api/Musics/5
        [ResponseType(typeof(Music))]
        public IHttpActionResult DeleteMusic(int id)
        {
            Music music = db.Music.Find(id);
            if (music == null)
            {
                return NotFound();
            }

            db.Music.Remove(music);
            db.SaveChanges();

            return Ok(music);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MusicExists(int id)
        {
            return db.Music.Count(e => e.ID_Music == id) > 0;
        }
    }
}