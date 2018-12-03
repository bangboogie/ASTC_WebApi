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
using ASTC_Webservice.DAL;
using ASTC_Webservice.Models;
using System.Web.Http.Cors;

namespace ASTC_Webservice.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VouchersController : ApiController
    {
        private ASTCContext db = new ASTCContext();

        //Custom made action methods:

       /* [Route("api/Vouchers")]
        [HttpPost]
        public IHttpActionResult RedeemVoucher(Models.Customer customer, Models.Voucher voucher, Models.UserVoucher userVoucher)
        {
            Boolean ok = false;
            if(ok) {  

                if (customer.Credit > voucher.VoucherCredit && voucher.VoucherCredit > 0)
                {
                    customer.Credit -= voucher.VoucherCredit;
                    ok = true;

                    var UserVoucher = new UserVoucher { VoucherID = voucher.ID, CustomerID = customer.ID };
                    var redeem = db.ReedemVoucher(userVoucher);

                    if (redeem == null )
                    {
                     return ResponseMessage(Request.CreateErrorResponse(
                    HttpStatusCode.NotImplemented, "Something went worng."
                    ));
                    }

                }

                else
                {
                    ok = false;
                    Console.WriteLine("Sadly you don't have enough points to redeem this voucher...");

                }
                
            }

            return Json(HttpStatusCode.OK);


        }

	*/


        // GET: api/Vouchers
        public IQueryable<Voucher> GetVouchers()
        {
            return db.Vouchers;
        }

        // GET: api/Vouchers/5
        [ResponseType(typeof(Voucher))]
        public IHttpActionResult GetVoucher(int id)
        {
            Voucher voucher = db.Vouchers.Find(id);
            if (voucher == null)
            {
                return NotFound();
            }

            return Ok(voucher);
        }

        // PUT: api/Vouchers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVoucher(int id, Voucher voucher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voucher.ID)
            {
                return BadRequest();
            }

            db.Entry(voucher).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoucherExists(id))
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

        // POST: api/Vouchers
        [ResponseType(typeof(Voucher))]
        public IHttpActionResult PostVoucher(Voucher voucher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vouchers.Add(voucher);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = voucher.ID }, voucher);
        }

        // DELETE: api/Vouchers/5
        [ResponseType(typeof(Voucher))]
        public IHttpActionResult DeleteVoucher(int id)
        {
            Voucher voucher = db.Vouchers.Find(id);
            if (voucher == null)
            {
                return NotFound();
            }

            db.Vouchers.Remove(voucher);
            db.SaveChanges();

            return Ok(voucher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoucherExists(int id)
        {
            return db.Vouchers.Count(e => e.ID == id) > 0;
        }
    }
}