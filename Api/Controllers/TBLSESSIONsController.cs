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
using Api.Models;
namespace Api.Controllers
{
    
    public class TBLSESSIONsController : ApiController
    {
        private Api.Models.RehabilitationDbEntities db = new Api.Models.RehabilitationDbEntities();

        // GET: api/TBLSESSIONs
        public IQueryable<TBLSESSION> GetTBLSESSION()
        {
            return db.TBLSESSION;
        }

        // GET: api/TBLSESSIONs/5
        [ResponseType(typeof(TBLSESSION))]
        public IHttpActionResult GetTBLSESSION(int id)
        {
            TBLSESSION tBLSESSION = db.TBLSESSION.Find(id);
            if (tBLSESSION == null)
            {
                return NotFound();
            }

            return Ok(tBLSESSION);
        }

        // PUT: api/TBLSESSIONs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTBLSESSION(int id, TBLSESSION tBLSESSION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tBLSESSION.ID)
            {
                return BadRequest();
            }

            db.Entry(tBLSESSION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TBLSESSIONExists(id))
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

        // POST: api/TBLSESSIONs
        [ResponseType(typeof(TBLSESSION))]
        public IHttpActionResult PostTBLSESSION(TBLSESSION tBLSESSION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TBLSESSION.Add(tBLSESSION);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tBLSESSION.ID }, tBLSESSION);
        }

        // DELETE: api/TBLSESSIONs/5
        [ResponseType(typeof(TBLSESSION))]
        public IHttpActionResult DeleteTBLSESSION(int id)
        {
            TBLSESSION tBLSESSION = db.TBLSESSION.Find(id);
            if (tBLSESSION == null)
            {
                return NotFound();
            }

            db.TBLSESSION.Remove(tBLSESSION);
            db.SaveChanges();

            return Ok(tBLSESSION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TBLSESSIONExists(int id)
        {
            return db.TBLSESSION.Count(e => e.ID == id) > 0;
        }
    }
}