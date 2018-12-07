using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ASTC_Webservice.DAL;
using ASTC_Webservice.Models;


namespace ASTC_Webservice.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserVouchersController : ApiController
    {
        private ASTCContext db = new ASTCContext();

        // GET: api/UserVouchers
        public IQueryable<UserVoucher> GetUserVouchers()
        {
            return db.UserVouchers;
        }

        // GET: api/UserVouchers/5
        [ResponseType(typeof(UserVoucher))]
        public IHttpActionResult GetUserVoucher(int id)
        {
            UserVoucher userVoucher = db.UserVouchers.Find(id);
            if (userVoucher == null)
            {
                return NotFound();
            }

            return Ok(userVoucher);
        }

        // PUT: api/UserVouchers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserVoucher(int id, UserVoucher userVoucher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userVoucher.ID)
            {
                return BadRequest();
            }

            db.Entry(userVoucher).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserVoucherExists(id))
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

        // POST: api/UserVouchers
        [ResponseType(typeof(UserVoucher))]
        public IHttpActionResult PostUserVoucher(UserVoucher userVoucher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserVouchers.Add(userVoucher);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userVoucher.ID }, userVoucher);
        }

        // DELETE: api/UserVouchers/5
        [ResponseType(typeof(UserVoucher))]
        public IHttpActionResult DeleteUserVoucher(int id)
        {
            UserVoucher userVoucher = db.UserVouchers.Find(id);
            if (userVoucher == null)
            {
                return NotFound();
            }

            db.UserVouchers.Remove(userVoucher);
            db.SaveChanges();

            return Ok(userVoucher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserVoucherExists(int id)
        {
            return db.UserVouchers.Count(e => e.ID == id) > 0;
        }
    }
}