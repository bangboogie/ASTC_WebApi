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

namespace ASTC_Webservice.Controllers
{
    public class ShopsController : ApiController
    {
        private ASTCContext db = new ASTCContext();

        // GET: api/Shops
        public IQueryable<Shop> GetShops()
        {
            return db.Shops;
        }

        // GET: api/Shops/5
        [ResponseType(typeof(Shop))]
        public IHttpActionResult GetShop(int id)
        {
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return NotFound();
            }

            return Ok(shop);
        }

        // PUT: api/Shops/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShop(int id, Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shop.ID)
            {
                return BadRequest();
            }

            db.Entry(shop).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopExists(id))
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

        // POST: api/Shops
        [ResponseType(typeof(Shop))]
        public IHttpActionResult PostShop(Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shops.Add(shop);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shop.ID }, shop);
        }

        // DELETE: api/Shops/5
        [ResponseType(typeof(Shop))]
        public IHttpActionResult DeleteShop(int id)
        {
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return NotFound();
            }

            db.Shops.Remove(shop);
            db.SaveChanges();

            return Ok(shop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShopExists(int id)
        {
            return db.Shops.Count(e => e.ID == id) > 0;
        }
    }
}