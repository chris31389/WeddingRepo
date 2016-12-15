using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wedding.Application.Core.ReferenceDatas;

namespace Wedding.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/reference")]
    [Authorize]
    public class ReferenceController : Controller
    {
        private readonly IReferenceDataService _referenceDataService;

        public ReferenceController(IReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;
        }

        [Route("weddingEvent"), HttpGet]
        public IActionResult GetWeddingEvents()
        {
            IEnumerable<ReferenceDataAdto> referenceDataAdtos = _referenceDataService.GetWeddingEvents();
            return Json(referenceDataAdtos);
        }

        [Route("starterMealChoice"), HttpGet]
        public IActionResult GetStarterMealChoice()
        {
            IEnumerable<ExtendedReferenceDataAdto> referenceDataAdtos = _referenceDataService.GetStarterMealChoice();
            return Json(referenceDataAdtos);
        }

        [Route("mainMealChoice"), HttpGet]
        public IActionResult GetMainMealChoice()
        {
            IEnumerable<ExtendedReferenceDataAdto> referenceDataAdtos = _referenceDataService.GetMainMealChoice();
            return Json(referenceDataAdtos);
        }

        [Route("dessertMealChoice"), HttpGet]
        public IActionResult GetDessertMealChoice()
        {
            IEnumerable<ExtendedReferenceDataAdto> referenceDataAdtos = _referenceDataService.GetDessertMealChoice();
            return Json(referenceDataAdtos);
        }
    }
}