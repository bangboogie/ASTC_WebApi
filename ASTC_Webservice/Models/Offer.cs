using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASTC_Webservice.Models
{
    public class Offer
    {
        public int ID { get; set; }
        public string OfferTitle { get; set; }
        public string OfferDesc { get; set; }
        public string OfferImg { get; set; }
        public DateTime OfferStart { get; set; }
        public DateTime OfferEnd { get; set; }

        //Foreign Key
        public int ShopID { get; set; }

        //Navigation property
        public virtual Shop Shop { get; set; }
    }
}