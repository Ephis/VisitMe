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
        public int reciverId { get; set; }
        [Required]
        public int cardId { get; set; }
        [Required]
        public int requestType { get; set; }

    }
}