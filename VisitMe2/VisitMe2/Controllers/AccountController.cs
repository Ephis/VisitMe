using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using VisitMe2.Models;

namespace VisitMe2.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;

        private VistmeContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AccountController()
        {
            _repo = new AuthRepository();
            _ctx = new VistmeContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }


        /// <summary>
        /// Create a new login
        /// </summary>
        /// <param name="login">String userName, String password, String email</param>
        /// <returns></returns>
        //POST api/Account/Register
        [ApiExplorerSettings(IgnoreApi = false)]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _repo.RegisterUser(login);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok(result);
        }

        [Authorize]
        [Route("CurrentUser")]
        public async Task<IHttpActionResult> GetCurrentUser()
        {

            var user = User.Identity.Name;

            return Ok(user);
        } 

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (String error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    //Ingen fejlkode, derfor sendes der bare en badrequest
                    return BadRequest();
                }
            }

            return null;

        }









    }
}
