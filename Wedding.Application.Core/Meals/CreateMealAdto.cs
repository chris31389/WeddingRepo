using System;

namespace Wedding.Application.Core.Meals
{
    public class CreateMealAdto
    {
        public Guid InviteeId { get; set; }
        
        public Guid StarterChoiceId { get; set; }

        public Guid MainChoiceId { get; set; }

        public Guid DessertChoiceId { get; set; }

        public string DietaryRequirements { get; set; }
    }
}