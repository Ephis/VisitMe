using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VisitMe2.Models.ViewModels
{
    public class RequestCardViewModel
    {
        [Required]
        public String reciverId { get; set; }
        [Required]
        public String cardId { get; set; }
        [Required]
        public int requestType { get; set; }

    }
}