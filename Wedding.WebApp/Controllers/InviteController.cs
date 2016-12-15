using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wedding.Application.Core.Invites;
using Wedding.WebApp.Authorisation;

namespace Wedding.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/invite")]
    [Authorize]
    public class InviteController : Controller
    {
        private readonly IInviteService _inviteService;
        private readonly UserManager<ApplicationUser> _applicationUserManager;

        public InviteController(
            IInviteService inviteService,
            UserManager<ApplicationUser> applicationUserManager)
        {
            _inviteService = inviteService;
            _applicationUserManager = applicationUserManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userIdString = _applicationUserManager.GetUserId(User);

            Guid userId;

            if (Guid.TryParse(userIdString, out userId))
            {
                InviteAdto inviteAdto = _inviteService.GetSingleByUserId(userId);
                return Json(inviteAdto);
            }
            
            return NotFound();
        }
    }
}