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
using Entities.Animal;
using MyDatabase;
using PersistanceGeneric;
using PersistanceGeneric.Repositories;

namespace Architecture1.Controllers.ApiControllers
{
    public class TigersController : ApiController
    {
        private ApplicationDbContext db;
        private GenericRepository<Tiger> genericService;

        public TigersController()
        {
            db=new ApplicationDbContext();
            genericService =  new GenericRepository<Tiger> (db);
        }

        // GET: api/Tigers
        public IHttpActionResult GetTigers()
        {
            var tigers = genericService.GetAll();
            return Json(tigers);
        }

        // GET: api/Tigers/5
        [ResponseType(typeof(Tiger))]
        public IHttpActionResult GetTiger(int id)
        {
            Tiger tiger = genericService.Get(id);
            if (tiger == null)
            {
                return NotFound();
            }

            return Ok(tiger);
        }

        // PUT: api/Tigers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTiger(int id, Tiger tiger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tiger.TigerId)
            {
                return BadRequest();
            }

            db.Entry(tiger).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TigerExists(id))
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

        // POST: api/Tigers
        [ResponseType(typeof(Tiger))]
        public IHttpActionResult PostTiger(Tiger tiger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tigers.Add(tiger);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tiger.TigerId }, tiger);
        }

        // DELETE: api/Tigers/5
        [ResponseType(typeof(Tiger))]
        public IHttpActionResult DeleteTiger(int id)
        {
            Tiger tiger = db.Tigers.Find(id);
            if (tiger == null)
            {
                return NotFound();
            }

            db.Tigers.Remove(tiger);
            db.SaveChanges();

            return Ok(tiger);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TigerExists(int id)
        {
            return db.Tigers.Count(e => e.TigerId == id) > 0;
        }
    }
}