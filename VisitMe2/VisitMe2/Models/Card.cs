using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisitMe2.Models
{
    public class Card
    {
        public int id { get; set; }
        public String fName { get; set; }
        public String lName { get; set; }
        public String phone { get; set; }
        public String fax { get; set; }
        public String email { get; set; }
        public String company { get; set; }
        public String position { get; set; }
    }
}