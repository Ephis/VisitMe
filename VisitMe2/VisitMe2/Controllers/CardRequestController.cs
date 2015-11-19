using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using VisitMe2.Models;
using VisitMe2.Models.ViewModels;

namespace VisitMe2.Controllers
{
    [RoutePrefix("api/request")]
    public class CardRequestController : ApiController
    {
        private UserManager<ApplicationUser> _userManager;
        private VistmeContext _ctx;

        public CardRequestController()
        {
            _ctx = new VistmeContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_ctx));

        }

        [Authorize]
        [Route("myrequests")]
        public IHttpActionResult GetMyRequests()
        {
            return Ok();
        }
    
        [Authorize]
        [Route("create")]
        public IHttpActionResult CreateRequest(RequestCardViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Account acc = getAccount();

            CardRequest request = new CardRequest();
            request.senderId = acc.id.ToString();
            request.reciverId = model.reciverId;
            request.cardId = model.cardId;
            request.requestType = request.getRequestTypeFromInt(model.requestType);

            _ctx.cardRequests.Add(request);
            _ctx.SaveChanges();
            
            return Ok();
        }

        [Authorize]
        [Route("accept")]
        public IHttpActionResult AcceptRequest()
        {
            return Ok();
        }

        [Authorize]
        [Route("reject")]
        public IHttpActionResult RejectRequest()
        {
            return Ok();
        }

        [Authorize]
        [Route("get/states")]
        public IHttpActionResult GetRequestStates()
        {
            return Ok(typeof (Card.CardState));
        }


        [Authorize]
        private Account getAccount()
        {
            var user = User.Identity.GetUserName();
            ApplicationUser real = (ApplicationUser)_userManager.FindByNameAsync(user).Result;
            return _ctx.accounts.FirstOrDefault(a => a.userId == real.Id);
        }

    }
}
