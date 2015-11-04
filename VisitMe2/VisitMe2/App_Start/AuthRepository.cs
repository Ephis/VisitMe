using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using VisitMe2.Models;

namespace VisitMe2
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(Login login)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = login.username
            };
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