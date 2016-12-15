using System;

namespace Wedding.Application.Core.Meals
{
    public class IndividualMealSelectionAdto
    {
        public Guid InviteeId { get; set; }

        public string FullName { get; set; }

        public bool IsAdult { get; set; }       

        public Guid? StarterChoice { get; set; }

        public Guid? MainChoice { get; set; }

        public Guid? DessertChoice { get; set; }

        public string DietaryRequirements { get; set; }
    }
}