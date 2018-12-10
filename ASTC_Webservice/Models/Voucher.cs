using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASTC_Webservice.Models
{
    public class Voucher
    {
        public int ID { get; set; }
        public string VoucherTitle { get; set; }
        public string VoucherDesc { get; set; }
        public string VoucherImg { get; set; }
        public int VoucherCredit { get; set; }
        public DateTime VoucherStart { get; set; }
        public DateTime VoucherEnd { get; set; }

        //Foreign Key
        public int ShopID { get; set; }

        //Navigation property
        public virtual Shop Shop { get; set; }


      


    }
}