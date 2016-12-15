using System;

namespace Wedding.WebApp.Controllers
{
    public class CreateIndividualMealSelectionWdto
    {
        public Guid InviteeId { get; set; }

        public string FullName { get; set; }

        public Guid StarterChoice { get; set; }

        public Guid MainChoice { get; set; }

        public Guid DessertChoice { get; set; }

        public string DietaryRequirements { get; set; }
    }
}