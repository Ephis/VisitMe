using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VisitMe2.Models
{
    public class Login
    {
        public int id { get; set; }
        [Required]
        public String username { get; set; }

        public String email { get; set; }

        [Required]
        public String password { get; set; }


    }
}