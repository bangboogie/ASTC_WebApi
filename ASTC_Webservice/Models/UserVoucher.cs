using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASTC_Webservice.Models
{
    public class UserVoucher
    {
        //Foreign Key
        public int VoucherID { get; set; }
        public int CustomerID { get; set; }

        //Navigation property
        public virtual Voucher Voucher { get; set; }
        public virtual Customer Customer { get; set; }
    }
}