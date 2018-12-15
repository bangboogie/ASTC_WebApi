using ASTC_Webservice.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASTC_Webservice.DAL
{
    public class ASTCContext : DbContext
    {
        //Connectionstring
        public ASTCContext() : base("name=ASTCContext") 
        {}
        //Assigning class to table in database
        public System.Data.Entity.DbSet<ASTC_Webservice.Models.Event> Events { get; set; } 

        public System.Data.Entity.DbSet<ASTC_Webservice.Models.Cat> Cats { get; set; }

        public System.Data.Entity.DbSet<ASTC_Webservice.Models.Offer> Offers { get; set; }

        public System.Data.Entity.DbSet<ASTC_Webservice.Models.UserVoucher> UserVouchers { get; set; }

        public System.Data.Entity.DbSet<ASTC_Webservice.Models.Shop> Shops { get; set; }

        public System.Data.Entity.DbSet<ASTC_Webservice.Models.Voucher> Vouchers { get; set; }

        public System.Data.Entity.DbSet<ASTC_Webservice.Models.Customer> Customers { get; set; }


        //Voucher: 

        public UserVoucher SaveVoucher(UserVoucher uservoucher)
        {
            var Reedem = UserVouchers.Add(uservoucher);

            SaveChanges();

            return Reedem;
        }


        public Voucher GetVoucherById(int id)
        {
            using (var entities = new ASTCContext())
            {
                var voucher = entities.Vouchers.FirstOrDefault(x => x.ID == id);

                return voucher;
            }
        }



        //this is corrected to the Customer controller. 
        public Customer CreateCustomerMember(Customer customer)
        {
            var cust = Customers.Add(customer);

            SaveChanges();

            return cust; 
        }


        public Customer UpdateCustomer(Customer customer)
        {

            var oldInfo = Customers.FirstOrDefault(x => x.ID == customer.ID);
            if(oldInfo != null)
            {
                Entry(oldInfo).CurrentValues.SetValues(customer);
                SaveChanges();
            }
           
            return oldInfo;
        }



        public Customer GetCustomerById(int id)
        {
            using (var entities = new ASTCContext())
            {
                var customer = entities.Customers.FirstOrDefault(x => x.ID == id);

                return customer;
            }
        }



        public Customer GetCustomerByEmail(string email)
        {
            using (var entities = new ASTCContext())
            {

                var customer = entities.Customers.FirstOrDefault(x => x.Email == email);

                return customer;
            }
        }


        public int GetCustomerIdByEmail(string email)
        {
            using (var entities = new ASTCContext())
            {

                int id = entities.Customers.Where(x => x.Email == email).Select(x => x.ID).SingleOrDefault();

                return id;
            }
        }


    }
}