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

        public List<Card> ownCards = new List<Card>();

        public List<Card> allowedCards = new List<Card>();

        public String userId { get; set; }

    }
}