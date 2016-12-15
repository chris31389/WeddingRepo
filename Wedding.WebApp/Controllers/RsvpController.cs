using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wedding.Application.Core.Rsvps;
using Wedding.WebApp.Authorisation;

namespace Wedding.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/rsvp")]
    [Authorize]
    public class RsvpController : Controller
    {
        private readonly IRsvpService _rsvpService;
        private readonly UserManager<ApplicationUser> _applicationUserManager;

        public RsvpController(
            IRsvpService rsvpService,
            UserManager<ApplicationUser> applicationUserManager)
        {
            _rsvpService = rsvpService;
            _applicationUserManager = applicationUserManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userIdString = _applicationUserManager.GetUserId(User);

            Guid userId;

            if (Guid.TryParse(userIdString, out userId))
            {
                RsvpAdto rsvpAdto = _rsvpService.GetByUserId(userId);
                return Json(rsvpAdto);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody]RsvpWdto rsvpWdto)
        {
            var userIdString = _applicationUserManager.GetUserId(User);

            Guid userId;

            if (Guid.TryParse(userIdString, out userId))
            {
                IEnumerable<CreateRsvpAdto> createRsvpAdtos = rsvpWdto.IndividualRsvps.Select(x => new CreateRsvpAdto
                {
                    InviteeId = x.InviteeId,
                    CanCome = x.CanCome
                });

                _rsvpService.AddRsvp(userId, rsvpWdto.Email, createRsvpAdtos);
                return Ok();
            }

            return NotFound();
        }
    }
}