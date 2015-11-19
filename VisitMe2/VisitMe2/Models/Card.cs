using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisitMe2.Models
{
    public class Card
    {
        public enum CardState
        {
            FreeForGrap = 1,
            RequestNeed = 2,
            Closed = 0
        }
        public int id { get; set; }
        public String fName { get; set; }
        public String lName { get; set; }
        public String phone { get; set; }
        public String fax { get; set; }
        public String email { get; set; }
        public String company { get; set; }
        public String position { get; set; }
        public int ownerId { get; set; }
        public CardState cardState { get; set; }

        public Card()
        {
            cardState = CardState.RequestNeed;
        }
    }
}