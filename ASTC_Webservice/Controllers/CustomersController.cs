using ASTC_Webservice.DAL;
using ASTC_Webservice.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Security.Claims;
using System.Diagnostics;

namespace ASTC_Webservice.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomersController : ApiController
    {
        private ASTCContext db = new ASTCContext();

        
        //public IQueryable<Customer> GetCustomers()
        //{
        //    return db.Customers;
        //}

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("api/Customer/LoginCheck")]
        public Customer LoginCheck(string email, string password)
        {
           
                var account = GetCustomerByEmail(email);

                Debug.WriteLine(account);
                if (account.Pass == password)
                    return account;
                else return null;
           
        }

        //Custom made action methods:
        [HttpPost]
        public IHttpActionResult CreateCustomerMember(Models.Customer customer)
        {
            var Customer = new Customer { Email = customer.Email, Lname = customer.Lname, Fname = customer.Fname, Pass = customer.Pass};

            var cust = db.CreateCustomerMember(customer);
            if (cust == null)
            {
                return ResponseMessage(Request.CreateErrorResponse(
                    HttpStatusCode.NotImplemented, "Something went worng."
                    ));

            }

            return Json(HttpStatusCode.OK);
        }

        

        [HttpGet]
        public Customer GetCustomerByEmail(string email)
        {

            var acc = db.GetCustomerByEmail(email);
            if (acc != null)
            {
                return acc;
            }
            else
            {
                var message = "Cound not find this account.";
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }


        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult CustomerID(int ID)
        {
            Customer customer = db.Customers.Find(ID);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.ID)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.ID }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.ID == id) > 0;
        }

      



        
    }
}