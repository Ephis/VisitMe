using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VisitMe2.Models
{
    public class Account
    {
        public int id { get; set; }
        public String fName { get; set; }
        public String lName { get; set; }
        public String email { get; set; }
        [Required]
        public String apiKey { get; set; }
        public List<Card> cards { get; set; }
        [Required]
        public Login login { get; set; }

    }
}