using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VisitMe2.Models
{
    public class Login
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "User name")]
        public String username { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public String email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String password { get; set; }

        public Account account = new Account();

        public void addAccount(Account account)
        {
            this.account = account;
        }


    }
}