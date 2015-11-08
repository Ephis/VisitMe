using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Login = VisitMe2.Models.Login;

namespace VisitMe2.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            Login login = new Login(returnUrl);
            var model = login;
            

            return View(model);
        }

        [HttpPost]
        public ActionResult LogIn(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Det her skal ÆNDRES OG DET ER VIGTIGT!!!
            //LÆS OVENSTÅENDE!!!
            if (model.username == "admin@admin.com" && model.password == "password")
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "Ben"),
                    new Claim(ClaimTypes.Email, "a@b.com"),
                    new Claim(ClaimTypes.Country, "England")},
           
                    "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.returnUrl));
            }

            return View();
        }

        public String GetRedirectUrl(string returnUrl)
        {
            if (String.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }
            return returnUrl;
        }
    }
}