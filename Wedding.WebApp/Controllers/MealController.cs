using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wedding.Application.Core.Meals;
using Wedding.WebApp.Authorisation;

namespace Wedding.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/meal")]
    [Authorize]
    public class MealController : Controller
    {
        private readonly IMealChoiceService _mealChoiceService;
        private readonly UserManager<ApplicationUser> _applicationUserManager;

        public MealController(IMealChoiceService mealChoiceService,
            UserManager<ApplicationUser> applicationUserManager)
        {
            _mealChoiceService = mealChoiceService;
            _applicationUserManager = applicationUserManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userIdString = _applicationUserManager.GetUserId(User);

            Guid userId;

            if (Guid.TryParse(userIdString, out userId))
            {
                MealAdto inviteAdto = _mealChoiceService.GetMealsByUserId(userId);
                return Json(inviteAdto);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateMealWdto mealAdto)
        {
            var userIdString = _applicationUserManager.GetUserId(User);

            Guid userId;

            if (Guid.TryParse(userIdString, out userId))
            {
                IEnumerable<CreateMealAdto> createMealAdtos = mealAdto.IndividualMealSelections.Select(x => new CreateMealAdto
                {
                    InviteeId = x.InviteeId,
                    StarterChoiceId = x.StarterChoice,
                    MainChoiceId = x.MainChoice,
                    DessertChoiceId = x.DessertChoice,
                    DietaryRequirements = x.DietaryRequirements
                });
                _mealChoiceService.AddMeal(userId, createMealAdtos);
                return Ok();
            }

            return NotFound();
        }
    }
}