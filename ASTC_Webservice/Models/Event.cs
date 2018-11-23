using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASTC_Webservice.Models
{
    public class Event
    {
        public int ID { get; set; }

        public string EventTitle { get; set; }

        public string EventDesc { get; set; }

        public string EventImg { get; set; }

        public DateTime EventStart { get; set; }

        public DateTime EventEnd { get; set; }

    }
}