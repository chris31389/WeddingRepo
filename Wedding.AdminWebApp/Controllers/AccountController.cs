using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wedding.AdminWebApp.Authorisation;
using Wedding.Application.Core;
using Wedding.Application.Core.Invites;

namespace Wedding.AdminWebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/account")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationUserDbContext _applicationUserDbContext;
        private readonly UserManager<ApplicationUser> _applicationUserManager;
        private readonly IInviteService _inviteService;

        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            ApplicationUserDbContext applicationUserDbContext,
            UserManager<ApplicationUser> applicationUserManager,
            IInviteService inviteService)
        {
            _signInManager = signInManager;
            _applicationUserDbContext = applicationUserDbContext;
            _applicationUserManager = applicationUserManager;
            _inviteService = inviteService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]IEnumerable<UserWdto> userWdtos)
        {
            List<CreateInviteAdto> createInviteAdtos = new List<CreateInviteAdto>();
            using (var dbContext = _applicationUserDbContext)
            {
                var sqlServerDatabase = dbContext.Database;
                if (sqlServerDatabase != null)
                {
                    foreach (var userWdto in userWdtos)
                    {
                        // add some users
                        ApplicationUser user = await _applicationUserManager.FindByNameAsync(userWdto.UserName);
                        if (user == null)
                        {
                            user = new ApplicationUser { UserName = userWdto.UserName };
                            await _applicationUserManager.CreateAsync(user, IdentityConstants.Password);

                            dbContext.SaveChanges();

                            Guid userId;
                            Guid.TryParse(user.Id, out userId);

                            IEnumerable<CreateInviteeAdto> createInviteeAdtos = userWdto.Invitees.Select(x => new CreateInviteeAdto
                            {
                                Fullname = x.Fullname,
                                IsAdult = x.IsAdult
                            });

                            createInviteAdtos.Add(new CreateInviteAdto
                            {
                                UserId = userId,
                                WeddingEventIds = userWdto.WeddingEventIds,
                                CreateInviteeAdtos = createInviteeAdtos
                            });
                        }
                    }
                }
            }

            if (createInviteAdtos.Count > 0)
            {
                var inviteAdtos = _inviteService.Create(createInviteAdtos);
                return Json(inviteAdtos);
            }
            return Ok();
        }
    }
}