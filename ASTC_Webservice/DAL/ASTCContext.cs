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
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public ASTCContext() : base("name=ASTCContext")
        {
        }

        public System.Data.Entity.DbSet<ASTC_Webservice.Models.Event> Events { get; set; }
        public System.Data.Entity.DbSet<ASTC_Webservice.Models.Cat> Cats { get; set; }

        public System.Data.Entity.DbSet<ASTC_Webservice.Models.Offer> Offers { get; set; }

       // public System.Data.Entity.DbSet<ASTC_Webservice.Models.UserVoucher> UserVouchers { get; set; }

        public System.Data.Entity.DbSet<ASTC_Webservice.Models.Shop> Shops { get; set; }

        public System.Data.Entity.DbSet<ASTC_Webservice.Models.Voucher> Vouchers { get; set; }

        public System.Data.Entity.DbSet<ASTC_Webservice.Models.Customer> Customers { get; set; }


        //Voucher: 
/*
        public UserVoucher ReedemVoucher(UserVoucher uservoucher)
        {
            var Reedem = UserVouchers.Add(uservoucher);

            SaveChanges();

            return Reedem;
        }

	*/

        //this is corrected to the Customer controller. 
        public Customer CreateCustomerMember(Customer customer)
        {
            var cust = Customers.Add(customer);

            SaveChanges();

            return cust; 
        }


        public Customer UpdateCustomerMember(Customer customer)
        {

            var oldInfo = Customers.FirstOrDefault(x => x.ID == customer.ID);
            if(oldInfo != null)
            {
                Entry(oldInfo).CurrentValues.SetValues(customer);
                SaveChanges();
            }
           
            return oldInfo;
        }




    }
}