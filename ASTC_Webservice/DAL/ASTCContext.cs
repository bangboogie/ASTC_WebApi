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


        public System.Data.Entity.DbSet<ASTC_Webservice.Models.Shop> Shops { get; set; }

        public System.Data.Entity.DbSet<ASTC_Webservice.Models.Voucher> Vouchers { get; set; }

        public System.Data.Entity.DbSet<ASTC_Webservice.Models.Customer> Customers { get; set; }



    }
}