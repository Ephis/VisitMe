using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using VisitMe2.Models;

namespace VisitMe2.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);


            using (AuthRepository _repo = new AuthRepository())
            {
                ApplicationUser user = (ApplicationUser) await _repo.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
                if (user.firstLogin == true)
                {
                    try
                    {
                        Account account = new Account();
                        account.userId = user.Id;
                        VistmeContext ctx = new VistmeContext();
                        ctx.accounts.Add(account);
                        ctx.SaveChanges();
                        user.firstLogin = false;
                        await _repo.UpdateUser(user);
                    }
                    catch (Exception e) { }
                }
            }

            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("role", "user"));
            identity.AddClaim(new Claim("username", context.UserName));

            context.Validated(identity);

        }
    }
}