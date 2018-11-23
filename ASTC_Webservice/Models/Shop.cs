using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASTC_Webservice.Models
{
    public class Shop
    {
        public int ID { get; set; }
        public string ShopName { get; set; }
        public string ShopDesc { get; set; }
        public string ShopImg { get; set; }
        public string ShopWeb { get; set; }
        public string ShopPhone { get; set; }

        //Foreign Key
        public int CatID { get; set; }

        //Navigation property
        public virtual Cat Cat { get; set; }

        //public virtual ICollection<Voucher> Vouchers
        //{
        //    get; set;

        //}

        //public virtual ICollection<Offer> Offers
        //{
        //    get; set;

        //}
    }
}