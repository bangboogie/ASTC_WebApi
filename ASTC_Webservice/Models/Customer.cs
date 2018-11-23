using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASTC_Webservice.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int Credit { get; set; }
        public string Barcode { get; set; }
    }
}