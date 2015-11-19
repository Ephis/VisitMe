using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using VisitMe2.Models;
using VisitMe2.Models.ViewModels;

namespace VisitMe2.Controllers
{
    [RoutePrefix("api/Card")]
    public class CardController : ApiController
    {
        private UserManager<ApplicationUser> _userManager;
        private VistmeContext _ctx;

        public CardController()
        {
            _ctx = new VistmeContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_ctx));

        }

        [Authorize]
        [Route("CreateCard")]
        public async Task<IHttpActionResult> CreateCard(CardViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Account acc = getAccount();

            Card card = new Card();

            card.company = returnEmptyStringIfNull(model.company);
            card.email = returnEmptyStringIfNull(model.email);
            card.fName = returnEmptyStringIfNull(model.fName);
            card.lName = returnEmptyStringIfNull(model.lName);
            card.fax = returnEmptyStringIfNull(model.fax);
            card.phone = returnEmptyStringIfNull(model.phone);
            card.position = returnEmptyStringIfNull(model.position);
            card.ownerId = acc.id;
            card = _ctx.cards.Add(card);
            _ctx.SaveChanges();

            return Ok(card);
        }

//        [Authorize]
//        [Route("AllowedCards")]
//        public IHttpActionResult GetAllAllowedCards()
//        {
//            
//        }

        [Authorize]
        [Route("EditCard")]
        public IHttpActionResult EditCard(Card card)
        {
            Account acc = getAccount();
            if (card.Equals(null))
            {
                return BadRequest();
            }
            if (card.ownerId == acc.id)
            {
                _ctx.cards.AddOrUpdate(card);
                _ctx.SaveChanges();
            }
            else
            {
                return BadRequest("Not allowed access");
            }
            return Ok(card);
        }


        [Authorize]
        [Route("MyCards")]
        public IHttpActionResult GetUsersCards()
        {
            VistmeContext db = new VistmeContext();
            Account acc = getAccount();
            return Ok(db.cards.Where( c => c.ownerId == acc.id));
        }

        [Authorize]
        private Account getAccount()
        {
            var user = User.Identity.GetUserName();
            ApplicationUser real = (ApplicationUser)_userManager.FindByNameAsync(user).Result;
            return _ctx.accounts.FirstOrDefault(a => a.userId == real.Id);
        }

        private String returnEmptyStringIfNull(String s)
        {
            if (s == null)
            {
                return "";
            }
            return s;
        }


    }
}
