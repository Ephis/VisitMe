using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using VisitMe2.Models;

namespace VisitMe2
{
    public class AuthRepository : IDisposable
    {
        private VistmeContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new VistmeContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(LoginViewModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.username,
                Email = model.email
            };

            //Adding the extra atributes
            user.account.fName = model.fName;
            user.account.lName = model.lName;

            var result = await _userManager.CreateAsync(user, model.password);

            return result;
        }

        public async Task<ApplicationUser> FindUser(string username, string password)
        {
            ApplicationUser user = (ApplicationUser) await _userManager.FindAsync(username, password);

            return user;
        }
         
        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}