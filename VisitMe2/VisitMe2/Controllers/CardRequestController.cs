using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
            Account acc = getAccount();
            return Ok(_ctx.cardRequests.Where(r => r.reciverId == acc.id || r.senderId == acc.id));
        }
    
        [Authorize]
        [Route("create")]
        public IHttpActionResult CreateRequest(RequestCardViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("ModelState is not valid");
            }

            Card.CardState cardState = _ctx.cards.FirstOrDefault(c => c.id == model.cardId).cardState;
            if (cardState == Card.CardState.Closed)
            {
                return BadRequest("Card can not be shared");
            }

            Account.AccountState reciverState = _ctx.accounts.FirstOrDefault(a => a.id == model.reciverId).accountState;
            if (reciverState != Account.AccountState.Open)
            {
                return BadRequest("Card can not be shared");
            }

            Account acc = getAccount();

            CardRequest request = new CardRequest();
            request.senderId = acc.id;
            request.reciverId = model.reciverId;
            request.cardId = model.cardId;
            request.requestType = request.getRequestTypeFromInt(model.requestType);

            _ctx.cardRequests.Add(request);
            _ctx.SaveChanges();
            
            return Ok();
        }

        [Authorize]
        [Route("accept")]
        public IHttpActionResult AcceptRequest(RequestIDviewModel model)
        {
            CardRequest request =_ctx.cardRequests.FirstOrDefault(r => r.id == model.requestId);
            Account acc = getAccount();
            if (request.reciverId != acc.id)
            {
                return BadRequest("You are not the reciver for this request");
            }

            if (request.requestState != CardRequest.RequestState.Standby)
            {
                if (request.requestState != CardRequest.RequestState.ReciverNotifyed)
                {
                    return BadRequest("You cannot make that action on this request");
                }
            }

            if (request.requestState == CardRequest.RequestState.RequestAccepted)
            {
                return Ok();
            }

            request.requestState = CardRequest.RequestState.RequestAccepted;
            _ctx.cardRequests.AddOrUpdate(request);
            _ctx.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [Route("reject")]
        public IHttpActionResult RejectRequest(RequestIDviewModel model)
        {
            CardRequest request = _ctx.cardRequests.FirstOrDefault(r => r.id == model.requestId);
            Account acc = getAccount();
            if (request.reciverId != acc.id)
            {
                return BadRequest("You are not the reciver for this request");
            }

            if (request.requestState != CardRequest.RequestState.ReciverNotifyed ||
                request.requestState != CardRequest.RequestState.Standby)
            {
                return BadRequest("You cannot make that action on this request");
            }

            if (request.requestState == CardRequest.RequestState.RequestRejected)
            {
                return Ok();
            }

            request.requestState = CardRequest.RequestState.RequestRejected;
            _ctx.cardRequests.AddOrUpdate(request);
            _ctx.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [Route("get/states")]
        public IHttpActionResult GetRequestStates()
        {
            return Ok(typeof (Card.CardState));
        }

        [Authorize]
        [Route("takeCard")]
        public IHttpActionResult TakeRequestedCard(RequestIDviewModel model)
        {
            CardRequest request = _ctx.cardRequests.FirstOrDefault(r => r.id == model.requestId);
            Account acc = getAccount();
            if (request.senderId != acc.id)
            {
                return BadRequest("You are not the reciver for this request");
            }

            if (request.requestState != CardRequest.RequestState.RequestAccepted)
            {
                if(request.requestState != CardRequest.RequestState.RequestRejected)
                return BadRequest("You cannot make that action on this request");
            }

            if (request.requestState == CardRequest.RequestState.Done)
            {
                return Ok();
            }

            if (request.requestState == CardRequest.RequestState.RequestRejected)
            {
                CardRequest returnRequest = request;
                request.requestState = CardRequest.RequestState.Done;
                _ctx.cardRequests.AddOrUpdate(request);
                _ctx.SaveChangesAsync();
                return Ok(returnRequest);
            }

            request.requestState = CardRequest.RequestState.Done;
            _ctx.cardRequests.AddOrUpdate(request);

            IQueryable<Card> cardQueryable = _ctx.cards.Where(c => c.id == request.cardId);
            Card card = cardQueryable.First();
            if (card != null)
            {
                acc.allowedCards.Add(card);
                _ctx.accounts.AddOrUpdate(acc);
            }


            _ctx.SaveChangesAsync();

            return Ok();
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
