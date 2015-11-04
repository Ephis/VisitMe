using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VisitMe2.Models
{
    public class RecivedCards
    {
        public int id { get; set; }
        [Required]
        public Account account { get; set; }
        [Required]
        public Card card { get; set; }
    }
}