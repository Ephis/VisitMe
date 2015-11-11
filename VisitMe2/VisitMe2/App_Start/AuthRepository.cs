using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<IdentityResult> RegisterUser(LoginViewModel login)
        {
            var user = new ApplicationUser
            {
                UserName = login.username,
                Email = login.email
            };

            user.account = login.account;
            var result = await _userManager.CreateAsync(user, login.password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string username, string password)
        {
            IdentityUser user = await _userManager.FindAsync(username, password);

            return user;
        }
         
        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}